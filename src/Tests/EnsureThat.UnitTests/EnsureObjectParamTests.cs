using System;
using EnsureThat.Resources;
using Xunit;

namespace EnsureThat.UnitTests
{
    public class EnsureObjectParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Fact]
        public void IsNotNull_WhenRefTypeIsNull_ThrowsArgumentNullException()
        {
            object value = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Ensure.That(value, ParamName).IsNotNull());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNull
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNull_WhenRefTypeIsNotNull_ReturnsPassedObjectInstance()
        {
            var item = new { Value = 42 };

            var returnedItem = Ensure.That(item, ParamName).IsNotNull();

            Assert.Equal(ParamName, returnedItem.Name);
            Assert.Equal(item, returnedItem.Value);
        }        
    }
}