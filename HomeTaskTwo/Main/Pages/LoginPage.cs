using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace HomeTaskTwo.Main.Pages
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement txtEmailId;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger']")]
        public IWebElement lblValidationMsg;

        [FindsBy(How = How.ClassName, Using = "logout")]
        public IWebElement btnLogOut;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign in')]")]
        public IWebElement btnSignInHeader;

        IWebDriver driver;
        public static String userName;
        public static String password;

        String test_url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";


        [SetUp]
        public void navigateToLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

        }
        public void logoutIfUserLoggedIn()
        {
            if (isDisplayed(btnLogOut))
            {
                btnLogOut.Click();
                
            }
        }

        private bool isDisplayed(IWebElement btnLogOut)
        {
            throw new NotImplementedException();
        }

        public void login(String emailId, String password)
        {
            txtEmailId.Clear();
            txtEmailId.SendKeys(emailId);
            txtPassword.Clear();
            txtPassword.SendKeys(password);
            btnSignIn.Click();
        }

        [Obsolete]
        public void clickOnLogoutButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(btnLogOut));
            btnLogOut.Click();
        }
    }
}
