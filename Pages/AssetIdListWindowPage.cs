using Autotests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Autotests.Pages
{
    public class AssetIdListWindowPage : PageObject
    {
        public AssetIdListWindowPage(IWebDriver driver) : base(driver) { }

        public IWebElement SearchField => _driver.FindElement(By.Name("assetSearch")); //Xpath=//tagname[@attribute='value']

        public IWebElement CloseNoSaveButton => _driver.FindElement(By.CssSelector("button[class='btn btn-outline-secondary mr-3 my-1']"));

        public IWebElement SaveAndCloseBreakdownButton => _driver.FindElement(By.CssSelector("button[class='btn confirm-button my-1']"));

        public IWebElement SaveAndClosePlannedButton => _driver.FindElement(By.Id("saveChangesButtonPlanned"));


        //public AssetIdListWindowPage TypeinSearchField()
        //{
        //    SearchField.SendKeys("INV");
        //    return this;
        //}

        public AssetIdListWindowPage SelectFirstAssetId()
        {
            var action = new Actions(_driver);
            IWebElement checkbox1 = _driver.FindElement(By.Name("AssetList.AssetList[0].IsActive")); // INV-1
            action.MoveToElement(checkbox1).Click().Perform();
            return this;
        }
        public AssetIdListWindowPage SelectSecondAssetId()
        {
            var action = new Actions(_driver);
            IWebElement checkbox2 = _driver.FindElement(By.Name("AssetList.AssetList[1].IsActive")); // INV-2
            action.MoveToElement(checkbox2).Click().Perform();
            return this;
        }
        public AssetIdListWindowPage ClickSaveAndClosePlannedButton()
        {
            SaveAndClosePlannedButton.Click();
            return this;
        }
        public AssetIdListWindowPage ClickSaveAndCloseBreakdownButton()
        {
            SaveAndCloseBreakdownButton.Click();
            return this;
        }
    }
}
