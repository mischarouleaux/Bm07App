using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bm07App.Business.Services;
using Bm07App.WebApi.Helpers;

namespace Bm07App.UnitTest.User
{
    [TestClass]
    public class TestLoginUser
    {
        /*
        byte[] hashedPassword = Helpers.Hasher.HashString(password);
        ApplicationUser user = _userService.GetUserByCredentials(username, hashedPassword);
        bool isValidCredentials = user != null;
        string userSessionToken = isValidCredentials ? _tokenService.GetSessionToken(user) : string.Empty;

        var responseData = new
        {
            IsValidCredentials = isValidCredentials,
            SessionToken = userSessionToken
        };
        */

        //[TestMethod]
        //public void TestValidLogin()
        //{
        //    string username = "IDormans";
        //    byte[] password = Hasher.HashString("B3stP@ssword");

        //    Tuple<bool, string> expected = Tuple.Create(true, "SomeToken");

        //    Tuple<bool, string> loginResult = ApplicationUserService.Login(username, password);

        //    Assert.AreEqual(expected.Item1, loginResult.Item1);
        //    Assert.IsNotNull(loginResult.Item2);
        //}

        //[TestMethod]
        //public void TestInvalidLoging()
        //{
        //    string username = "KDormans";
        //    byte[] password = Hasher.HashString("Guessed");

        //    Tuple<bool, string> expected = Tuple.Create<bool, string>(false, null);

        //    Tuple<bool, string> loginResult = ApplicationUserService.Login(username, password);

        //    Assert.AreEqual(expected.Item1, loginResult.Item1);
        //    Assert.IsNull(loginResult.Item2);
        //}
    }
}
