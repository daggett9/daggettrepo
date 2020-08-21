using Autotests.PageObjects;
using OpenQA.Selenium;

namespace Autotests.Pages
{
    class OneDriveLoginPage : PageObject
    {
        public OneDriveLoginPage(IWebDriver driver) : base(driver) { }

        public IWebElement MicrosoftLoginField => _driver.FindElement(By.Id("i0116"));
        public IWebElement NextButton => _driver.FindElement(By.Id("idSIButton9"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("i0118"));
        public IWebElement SignInButton => _driver.FindElement(By.Id("idSIButton9"));

        public OneDriveLoginPage EnterMicrosoftLogin()
        {
            MicrosoftLoginField.SendKeys("testr234j@outlook.com");
            return this;
        }
        public OneDriveLoginPage ClickNextButton()
        {
            NextButton.Click();
            Wait.Until(_driver => PasswordField.Displayed);
            return this;
        }
        public OneDriveLoginPage EnterPassword()
        {
            PasswordField.SendKeys("qwexol123@");
            return this;
        }
        public OneDriveLoginPage ClickSignInButton()
        {
            SignInButton.Click();
            return this;
        }
    }
}
