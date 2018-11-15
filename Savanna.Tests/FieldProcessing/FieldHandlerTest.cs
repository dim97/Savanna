using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models.Animals;
using Savanna.Services;
using System.Collections.Generic;

namespace Savanna.Tests
{
    [TestClass]
    public class FieldHandlerTest
    {
        public Mock<IField> GameField;
        private IFieldHandler _systemUnderTest;

        [TestInitialize]
        public void Setup()
        {
            GameField = new Mock<IField>();

            IAnimal[,] defaultAnimals = new IAnimal[2, 3];

            defaultAnimals[0, 0] = new Antilope();
            defaultAnimals[0, 1] = new Antilope();
            defaultAnimals[0, 2] = new Lion();
            defaultAnimals[1, 0] = null;
            defaultAnimals[1, 1] = null;
            defaultAnimals[1, 2] = new Lion();

            GameField.Setup(f => f.Width).Returns(3);
            GameField.Setup(f => f.Heigth).Returns(2);
            GameField.Setup(f => f.Animals).Returns(defaultAnimals);

            _systemUnderTest = new FieldHandler(GameField.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            GameField = null;
            _systemUnderTest = null;
        }

        [TestMethod]
        public void GetFieldInStringList_should_return_list_of_strings_that_represents_animal_positions_in_field()
        {
            //Act
            List<string> result = _systemUnderTest.GetFieldInStringList();

            //Assert
            Assert.AreEqual("A A L ", result[0]);
            Assert.AreEqual("    L ", result[1]);
        }

        [TestMethod]
        public void IsFull_should_return_true_when_field_is_full()
        {
            //Arrange
            GameField.Object.Animals[1, 0] = new Antilope();
            GameField.Object.Animals[1, 1] = new Antilope();

            //Act
            bool result = _systemUnderTest.IsFull;

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsFull_should_return_false_when_field_is_not_full()
        {
            //Act
            bool result = _systemUnderTest.IsFull;

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}


