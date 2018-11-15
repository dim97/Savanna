using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Services;

namespace Savanna.Tests
{
    [TestClass]
    public class AnimalPlacerTest
    {
        private Mock<IFieldHandler> _fieldHandler;
        private Mock<IField> _field;
        private IAnimalPlacer _sut;

        [TestInitialize]
        public void Setup()
        {
            //Arrange 
            _field = new Mock<IField>();
            _fieldHandler = new Mock<IFieldHandler>();
            _sut = new AnimalPlacer(_fieldHandler.Object);
            //Act
            //Assert
        }
    }
}
