using Xunit;
using MscrmTools.EnvironmentVariableManager.AppCode;

namespace MscrmTools.EnvironmentVariableManager.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestValidateBoolean()
        {
            Assert.True(Validator.ValidateBoolean("yes"));
            Assert.True(Validator.ValidateBoolean("no"));
            Assert.False(Validator.ValidateBoolean("Yes"));
            Assert.False(Validator.ValidateBoolean("No"));
            Assert.False(Validator.ValidateBoolean("true"));
            Assert.False(Validator.ValidateBoolean("false"));
            Assert.False(Validator.ValidateBoolean("1"));
            Assert.False(Validator.ValidateBoolean("0"));
            Assert.False(Validator.ValidateBoolean("test"));
        }
    }
}