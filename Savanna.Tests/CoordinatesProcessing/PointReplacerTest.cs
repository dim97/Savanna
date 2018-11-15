using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models.Animals;
using Savanna.Services;
using System.Drawing;

namespace Savanna.Tests
{
    [TestClass]
    public class PointReplacerTest
    {
        private Mock<IField> _field;
        private Mock<IPositionChecker> _positionChecker;
        private IPointReplacer _systemUnderTest;

        Point _start;
        Point _destination;

        [TestInitialize]
        public void Setup()
        {
            _start = new Point(1, 0);
            _destination = new Point(0, 1);

            _field = new Mock<IField>();
            _positionChecker = new Mock<IPositionChecker>();
            IAnimal[,] defaultAnimals = new IAnimal[2, 3];

            _field.Setup(f => f.Width).Returns(3);
            _field.Setup(f => f.Heigth).Returns(2);
            _field.Setup(f => f.Animals).Returns(defaultAnimals);

            _systemUnderTest = new PointReplacer(_positionChecker.Object, _field.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _start = Point.Empty;
            _destination = Point.Empty;
            _positionChecker = null;
            _field = null;
            _systemUnderTest = null;
        }

        [TestMethod]
        public void ReplacePoint_should_remove_animal_from_start_position_in_field_and_place_to_destination()
        {
            //Arrange 
            _field.Object.Animals[0, 1] = new Antilope();
            _field.Object.Animals[1, 0] = null;

            //Act
            _systemUnderTest.ReplacePoint(_start, _destination);

            //Assert
            _field.VerifyGet(x => x.Animals, Times.AtLeastOnce);
            Assert.IsNull(_field.Object.Animals[0, 1]);
            Assert.IsInstanceOfType(_field.Object.Animals[1, 0], typeof(Antilope));
        }

        [TestMethod]
        public void ReplacePoint_should_not_to_move_empty_place()
        {
            //Arrange
            _field.Object.Animals[0, 1] = null;
            _field.Object.Animals[1, 0] = new Antilope();

            //Act
            _systemUnderTest.ReplacePoint(_start, _destination);

            //Assert
            _field.VerifyGet(x => x.Animals, Times.AtLeastOnce);
            Assert.IsNull(_field.Object.Animals[0, 1]);
            Assert.IsInstanceOfType(_field.Object.Animals[1, 0], typeof(Antilope));
        }

        [TestMethod]
        public void ReplacePoint_should_not_move_or_remove_animal_when_start_and_destination_positions_are_same()
        {
            //Arrange
            _field.Object.Animals[0, 1] = new Antilope();
            _destination = _start;

            //Act
            _systemUnderTest.ReplacePoint(_start, _destination);

            //Assert
            _field.VerifyGet(x => x.Animals, Times.AtLeast(2));
            Assert.IsInstanceOfType(_field.Object.Animals[0, 1], typeof(Antilope));
        }

        [TestMethod]
        public void ReplacePoint_should_replace_animal_in_destination_position_on_animal_from_old_position_when_destination_is_not_empty()
        {
            //Arrange
            _field.Object.Animals[0, 1] = new Lion();
            _field.Object.Animals[1, 0] = new Antilope();

            //Act
            _systemUnderTest.ReplacePoint(_start, _destination);

            //Assert
            Assert.IsInstanceOfType(_field.Object.Animals[1, 0], typeof(Lion));
            Assert.IsNull(_field.Object.Animals[0, 1]);
        }
    }
}
