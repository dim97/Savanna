using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savanna.Interfaces.Models;
using Moq;
using Savanna.Interfaces.Services;
using Savanna.Services;
using Savanna.Models.Animals;
using System.Drawing;
using System.Collections.Generic;
using Savanna.Interfaces;
using Savanna.Models;
using System.Text;
using Savanna.Factories;

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
            //Arrang
            DrawingSymbols drawingSymbols = new DrawingSymbols();
            List<string> expectedRerult = new List<string>();

            //Act
            List<string> result = _systemUnderTest.GetFieldInStringList();

            //Assert
            Assert.AreEqual("A A L ",result[0]);
            Assert.AreEqual("    L ", result[1]);
        }

        //[TestMethod]
        //public void GetFieldInStringList_should_return_empty__list_of_strings_when_field_is_null()
        //{
        //    //Arrang
        //    DrawingSymbols drawingSymbols = new DrawingSymbols();
        //    List<string> expectedRerult = new List<string>();
        //    _sut.GameField = null;

        //    //Act
        //    List<string> result = _sut.GetFieldInStringList();

        //    //Assert
            
        //}
    }
}


