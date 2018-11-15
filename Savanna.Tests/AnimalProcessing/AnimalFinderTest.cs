using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savanna.Enums;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models.Animals;
using Savanna.Services;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Tests
{
    [TestClass]
    public class AnimalFinderTest
    {
        private Mock<IField> _field;
        private Mock<IDistanceHandler> _distanceHandler;
        private Mock<IPositionChecker> _positionChecker;
        private IAnimalFinder _systemUnderTest;

        private Point _position;
        private Point _result;
        private List<Point> _resultList;

        [TestInitialize]
        public void Setup()
        {
            _field = new Mock<IField>();
            _distanceHandler = new Mock<IDistanceHandler>();
            _positionChecker = new Mock<IPositionChecker>();

            _position = new Point(0, 0);

            IAnimal[,] defaultAnimals = new IAnimal[2, 3];

            defaultAnimals[0, 0] = new Antilope();
            defaultAnimals[0, 1] = new Antilope();
            defaultAnimals[0, 2] = new Lion();
            defaultAnimals[1, 0] = null;
            defaultAnimals[1, 1] = null;
            defaultAnimals[1, 2] = new Lion();

            _field.Setup(f => f.Width).Returns(3);
            _field.Setup(f => f.Heigth).Returns(2);
            _field.Setup(f => f.Animals).Returns(defaultAnimals);

            List<Point> ExistingAnimals = new List<Point>();
            ExistingAnimals.Add(new Point(0, 0));
            ExistingAnimals.Add(new Point(1, 0));
            ExistingAnimals.Add(new Point(2, 1));
            ExistingAnimals.Add(new Point(2, 0));

            _positionChecker.Setup(f => f.CheckEmpty(It.IsIn<Point>(ExistingAnimals))).Returns(false);
            _positionChecker.Setup(f => f.CheckEmpty(It.IsNotIn<Point>(ExistingAnimals))).Returns(true);

            _systemUnderTest = new AnimalFinder(_field.Object, _positionChecker.Object, _distanceHandler.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _positionChecker = null;
            _distanceHandler = null;
            _field = null;
            _systemUnderTest = null;

            _position = Point.Empty;
            _resultList = null;
        }

        [TestMethod]
        public void FindNearestAnimals_should_return_list_of_points_with_nearby_animals_positions()
        {
            //Arrange 
            _field.Object.Animals[0, 0].VisionRange = 2;

            //Act
            _resultList = _systemUnderTest.FindNearestAnimals(_position);

            //Assert     
            Assert.AreEqual(1, _resultList.Count);
            Assert.IsInstanceOfType(_field.Object.Animals[_resultList[0].Y, _resultList[0].X], typeof(Antilope));
        }

        [TestMethod]
        public void FindNearestAnimalsWithNoVisionRange_should_return_empty_list_of_points()
        {
            //Arrange 
            _field.Object.Animals[0, 0].VisionRange = 0;

            //Act
            _resultList = _systemUnderTest.FindNearestAnimals(_position);

            //Assert     
            _field.VerifyGet(x => x.Animals, Times.AtLeast(2));
            Assert.AreEqual(0, _resultList.Count);
        }

        [TestMethod]
        public void SelectNearestAnimalByTypeCarnivore_should_return_point_with_position_of_nearby_carnivore()
        {
            //Arrange 
            Point expectedResult = new Point(2, 0);
            _field.Object.Animals[0, 0].VisionRange = 5;

            //Act
            _result = _systemUnderTest.SelectNearestAnimalByType(_position, AnimalType.Carnivore);

            //Assert
            Assert.AreEqual(expectedResult, _result);
        }

        [TestMethod]
        public void SelectNearestAnimalByType_should_return_point_with_default_position_when_on_field_are_no_any_carnivores()
        {
            //Arrange 
            Point expectedResult = new Point(-1, -1);
            _field.Object.Animals[0, 0].VisionRange = 2;
            _field.Object.Animals[0, 1] = new Antilope();
            _field.Object.Animals[0, 2] = new Antilope();

            //Act
            _result = _systemUnderTest.SelectNearestAnimalByType(_position, AnimalType.Carnivore);

            //Assert
            Assert.AreEqual(expectedResult, _result);
        }

        [TestMethod]
        public void SelectNearestAnimalByTypeHerbivore_should_return_point_with_position_of_nearby_herbivore()
        {
            //Arrange
            Point expectedResult = new Point(1, 0);
            _field.Object.Animals[0, 0].VisionRange = 2;

            //Act
            _result = _systemUnderTest.SelectNearestAnimalByType(_position, AnimalType.Herbivore);

            //Assert
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
