using HomeTaskTwo.Main.Pages;

namespace HomeTaskTwo.Features
{
    public class DomainHelper
    {
		private AccountPage accountPage;
		private LoginPage loginPage;

		internal AccountPage GetAccountPage()
		{
			if (accountPage == null)
			{
				accountPage = new AccountPage();
			}
			return accountPage;
		}

		internal LoginPage GetLoginPage()
		{
			if (loginPage == null)
			{
				loginPage = new LoginPage();
			}
			return loginPage;
		}

	}
}