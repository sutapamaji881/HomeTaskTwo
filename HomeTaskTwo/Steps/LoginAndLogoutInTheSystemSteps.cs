using HomeTaskTwo.Main.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HomeTaskTwo.Features
{
    [Binding]
    public class LoginAndLogoutInTheSystemSteps
    {
        private DomainHelper domainHelper;

        public LoginAndLogoutInTheSystemSteps(DomainHelper domainHelper)
        {
            this.domainHelper = domainHelper;
        }

        [Given(@"login page is opened")]
        public void GivenLoginPageIsOpened()
        {
            domainHelper.GetLoginPage().navigateToLoginPage();
        }
        
        [Given(@"user is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            domainHelper.GetLoginPage().logoutIfUserLoggedIn();
        }
        
        [When(@"user enters invalid credentials")]
        public void WhenUserEntersInvalidCredentials()
        {
            domainHelper.GetLoginPage().login("test@gmail.com", "test");
            Assert.AreEqual("Validation message displayed", domainHelper.GetLoginPage().lblValidationMsg.Displayed);
        }

        [When(@"user doesn't enter credentials")]
        public void WhenUserDoesnTEnterCredentials()
        {
            domainHelper.GetLoginPage().login("", "");
            Assert.AreEqual("Validation message displayed", domainHelper.GetLoginPage().lblValidationMsg.Displayed);

        }

        [When(@"user enters valid credentials")]
        public void WhenUserEntersValidCredentials()
        {
            domainHelper.GetLoginPage().login(LoginPage.userName, LoginPage.password);
        }

        [Then(@"user should be logged in")]
        public void ThenUserShouldBeLoggedIn()
        {
            Assert.AreEqual("User is logged in", domainHelper.GetLoginPage().btnLogOut.Displayed);
        }

        [When(@"use clicks logout button")]
        public void WhenUseClicksLogoutButton()
        {
            domainHelper.GetLoginPage().clickOnLogoutButton();
        }

        [Then(@"user should be logged out")]
        public void ThenUserShouldBeLoggedOut()
        {
            Assert.AreEqual("User logged out", domainHelper.GetLoginPage().btnSignInHeader.Displayed);
        }

        [Then(@"validation message should be displayed for invalid credentials")]
        public void ThenValidationMessageShouldBeDisplayedForInvalidCredentials()
        {
            Assert.AreEqual("Validation message displayed",
                domainHelper.GetLoginPage().lblValidationMsg.Displayed);

        }
    }
}
