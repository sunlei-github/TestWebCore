using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Common.Utitly;
using WebApi.Core.Enum.User;

namespace WebApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestEnum();

        }

        private void TestEnum()
        {
            string enumDirection = EnumUntitly.GetEnumDirection(SexEnum.Man);

            var directions = EnumUntitly.GetEnumArrayDirection(typeof(SexEnum));
        }
    }
}
