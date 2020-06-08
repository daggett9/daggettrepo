using Autotests.PageObjects;
using OpenQA.Selenium;

namespace Autotests.Pages
{
    class LoginPage : PageObject
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public IWebElement UserName => _driver.FindElement(By.Id("user-email"));

        public IWebElement Password => _driver.FindElement(By.Id("user-password"));

        public IWebElement Submit => _driver.FindElement(By.ClassName("submit-btn"));


        public void Login(string login, string password)
        {
            UserName.SendKeys(login);
            Password.SendKeys(password);
            Submit.Click();
        }
    }
}
