using HomeTaskTwo.Main.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HomeTaskTwo.Features
{
    [Binding]
    public class UserRegistrationSteps
    {
        private DomainHelper domainHelper;

        public UserRegistrationSteps(DomainHelper domainHelper)
        {
            this.domainHelper = domainHelper;
        }

        [Given(@"create account page is opened")]
        public void GivenCreateAccountPageIsOpened()
        {
            domainHelper.GetAccountPage().navigateToCreateAccountPage();
        }

        [When(@"user enters duplicate email id and submits it")]
        public void WhenUserEntersDuplicateEmailIdAndSubmitsIt()
        {
            domainHelper.GetAccountPage().registerWithEmail(true);
        }

        [When(@"user enters unique email id and submits it")]
        public void WhenUserEntersUniqueEmailIdAndSubmitsIt()
        {
            domainHelper.GetAccountPage().registerWithEmail(false);
        }

        [Then(@"validation message should be displayed")]
        public void ThenValidationMessageShouldBeDisplayed()
        {

            Assert.AreEqual("Validation message displayed",
                domainHelper.GetAccountPage().lblCreateAccountError.Displayed);
        }

        [Then(@"account creation form should be displayed")]
        public void ThenAccountCreationFormShouldBeDisplayed()
        {
            Assert.AreEqual("Account creation form displayed",
                domainHelper.GetAccountPage().accountCreationForm.Displayed);

        }

        [When(@"user enters data in account creation form and submits it")]
        public void WhenUserEntersDataInAccountCreationFormAndSubmitsIt()
        {
            domainHelper.GetAccountPage().createAccount();
        }

        [Then(@"account should be created")]
        public void validateLogOutButton()
        {
            Assert.AreEqual("LogOut button displayed", domainHelper.GetAccountPage().btnLogOut.Displayed);
            if (domainHelper.GetAccountPage().btnLogOut.Displayed)
            {
                LoginPage.userName = AccountPage.userName;
                LoginPage.password = AccountPage.password;
            }

        }

        [When(@"user clicks on register button")]
        public void WhenUserClicksOnRegisterButton()
        {
            domainHelper.GetAccountPage().clickOnRegisterButton();
        }

        [Then(@"validation message should be displayed for mandatory fields")]
        public void ThenValidationMessageShouldBeDisplayedForMandatoryFields()
        {
            Assert.AreEqual("Validation message for mandatory fields displayed",
                domainHelper.GetAccountPage().lblRegisterErrorMsg.Displayed);

        }
       
    }
}
