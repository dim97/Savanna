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

        [TestInitialize]
        public void Setup()
        {
            _field = new Mock<IField>();
            _fieldHandler = new Mock<IFieldHandler>();
        }
    }
}
