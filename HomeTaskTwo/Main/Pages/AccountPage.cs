
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace HomeTaskTwo.Main.Pages
{
    public class AccountPage
    {

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign in')]")]
        private IWebElement btnSignIn { get; set; }

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement txtEmailId;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitCreate']")]
        private IWebElement btnCreateAccount;

        [FindsBy(How = How.Id, Using = "create_account_error")]
        public IWebElement lblCreateAccountError;

        [FindsBy(How = How.Id, Using = "account-creation_form")]
        public IWebElement accountCreationForm;

        [FindsBy(How = How.ClassName, Using = "logout")]
        public IWebElement btnLogOut;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement txtFname;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement txtLname;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement txtAddressLine1;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement txtCity;

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement ddState;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement txtPostcode;

        [FindsBy(How = How.Id, Using = "id_country")]
        private IWebElement ddCountry;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement txtMobileNo;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement btnRegister;

        [FindsBy(How = How.ClassName, Using = "alert alert-danger")]
        public IWebElement lblRegisterErrorMsg;

        IWebDriver driver;

        public static String userName;
        public static String password;
        
        
        String test_url = "http://automationpractice.com/";

        [SetUp]
        public void navigateToCreateAccountPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;
            btnSignIn.Click();
        }
        public void registerWithEmail(Boolean isDuplicate)
        {
            userName = isDuplicate ? "test@gmail.com" : "TestEmail" + new Random().NextDouble() + "@testqa.com";
            txtEmailId.SendKeys(userName);
            btnCreateAccount.Click();

        }
        public void createAccount()
        {
            txtFname.SendKeys("Test");
            txtLname.SendKeys("Test");
            password = "Test" + new Random().NextDouble() + "!@#";
            txtPassword.SendKeys(password);
            txtAddressLine1.SendKeys("Test");
            txtCity.SendKeys("NY");

            SelectElement state_dd = new SelectElement(ddState);
            state_dd.SelectByValue("2");
            txtPostcode.SendKeys("12345");
            SelectElement country_dd = new SelectElement(ddCountry);
            state_dd.SelectByValue("21");
            txtMobileNo.SendKeys("1234512345");
            clickOnRegisterButton();
        }

        public void clickOnRegisterButton()
        {
        btnRegister.Click();
		Thread.Sleep(5000);
		
	}


}
}
