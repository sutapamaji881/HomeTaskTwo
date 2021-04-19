using HomeTaskTwo.Main.Pages;
using HomeTaskTwo.Main.UserInfo;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HomeTaskTwo.Features
{
    [Binding]
    public class LoginAndLogoutInTheSystemSteps
    {
        private DomainHelper domainHelper;
        private UserInfo userInfo;

        public LoginAndLogoutInTheSystemSteps(DomainHelper domainHelper)
        {
            this.domainHelper = domainHelper;
        }
       

        public LoginAndLogoutInTheSystemSteps(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }

        [Given(@"login page is opened")]
        public void GivenLoginPageIsOpened()
        {
            domainHelper.GetLoginPage().navigateToLoginPage();
        }
        [When(@"enter the ""(.*)"" inside email address text box")]
        public void WhenEnterTheInsideEmailAddressTextBox(String email)
        {
            domainHelper.GetLoginPage().enterEmail(email);
        }

        [When(@"enter the ""(.*)"" inside password text box")]
        public void WhenEnterTheInsidePasswordTextBox(String password)
        {
            domainHelper.GetLoginPage().enterPassword(password);
        }

        [Then(@"verify that ""(.*)"" for the given credentials")]
        public void ThenVerifyThatForTheGivenCredentials(string message)
        {
            Assert.AreEqual("Message [" + message + "] is not displayed.", domainHelper.GetLoginPage().lblValidationMsg.Displayed);
        }

        [Given(@"verify that Login option is visible on sign in page")]
        public void WhenVerifyThatLoginOptionIsVisibleOnSignInPage()
        {
            domainHelper.GetLoginPage().navigateToLoginPage();
        }

        [Then(@"click on the ""(.*)"" button")]
        public void ThenClickOnTheButton()
        {
            domainHelper.GetLoginPage().clickOnLoginButton();
        }

        [Given(@"user is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            domainHelper.GetLoginPage().logoutIfUserLoggedIn();
        }
        [When(@"user enters valid credentials")]
        public void WhenUserEntersValidCredentials()
        {
            domainHelper.GetLoginPage().login(userInfo.GetUserEmail(), userInfo.GetUserEmail());
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

    }
}
