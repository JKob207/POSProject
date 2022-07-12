using System;
using Xunit;

namespace POSTests
{
    public class UnitTest1
    {
        [Fact]
        public void GoodLogin()
        {
            POSProject.UserLogin user = new POSProject.UserLogin();

            bool result = user.Login(1111, 1111);

            Assert.True(result);
        }

        [Fact]
        public void BadLogin()
        {
            POSProject.UserLogin user = new POSProject.UserLogin();

            bool result = user.Login(1111, 11);

            Assert.False(result);
        }
    }
}
