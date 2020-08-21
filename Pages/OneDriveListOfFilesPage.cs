using Autotests.PageObjects;
using OpenQA.Selenium;

namespace Autotests.Pages
{
    class OneDriveListOfFilesPage : PageObject
    {
        public OneDriveListOfFilesPage(IWebDriver driver) : base(driver) { }

        public IWebElement FileCheckbox => _driver.FindElement(By.XPath("//ul[@class='bstree-children']//span[@class='checkmark']"));
        public IWebElement PlusIcon => _driver.FindElement(By.XPath("//i[@class='fa fa-plus']"));
        public IWebElement SelectButton => _driver.FindElement(By.CssSelector("button[onclick='uploadManualOneDriveFile()']"));

        public OneDriveListOfFilesPage ClickPlusIcon()
        {
            PlusIcon.Click();
            return this;
        }
        public OneDriveListOfFilesPage ClickFileCheckbox()
        {
            FileCheckbox.Click();
            return this;
        }
        public OneDriveListOfFilesPage ClickSelectButton()
        {
            SelectButton.Click();
            return this;
        }
    }
}
