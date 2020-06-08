using Autotests.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Pages
{
    class CreateDGRReportPage : PageObject
    {
        public CreateDGRReportPage(IWebDriver driver) : base(driver) { }

        public IWebElement DateField => _driver.FindElement(By.XPath("//input[@type='datetime']"));
        public IWebElement LossOfInsolationDueToGridFailureField => _driver.FindElement(By.XPath("//input[@id='lossOfInsolationDueToGridFailure']"));
        public IWebElement NextButton => _driver.FindElement(By.Id("btn-scada-data-next"));
        public IWebElement NextFromManualEntryButton => _driver.FindElement(By.Id("btn-manual-entry-next"));
        public IWebElement NextFromModuleCleaningButton => _driver.FindElement(By.Id("btn-module-cleaning-next"));
        public IWebElement SubmitButton => _driver.FindElement(By.Id("btn-action-and-analysis-next"));

        public CreateDGRReportPage OpenCreateDGRReportPage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/Reports/CreateDGRReport");
            return this;
        }
        public CreateDGRReportPage ClickDateField()
        {
            DateField.Click();
            return this;
        }
        public CreateDGRReportPage DeleteDefaultDate()
        {
            DateField.Clear();
            return this;
        }
        public CreateDGRReportPage TypeDate()
        {
            DateField.SendKeys("3/7/2020");
            return this;
        }
        public CreateDGRReportPage ClickLossOfInsolationDueToGridFailureField()
        {
            LossOfInsolationDueToGridFailureField.Click();
            return this;
        }
        public CreateDGRReportPage TypeLossOfInsolationDueToGridFailure()
        {
            LossOfInsolationDueToGridFailureField.SendKeys("55555");
            return this;
        }
        public CreateDGRReportPage ClickNextButton()
        {
            NextButton.Click();
            return this;
        }
        public CreateDGRReportPage WaitForNextFromManualEntryButton()
        {
            Wait.Until(_driver => NextFromManualEntryButton.Displayed);
            return this;
        }
        public CreateDGRReportPage ClickNextFromManualEntryButton()
        {
            NextFromManualEntryButton.Click();
            return this;
        }
        public CreateDGRReportPage WaitForNextFromModuleCleaningButton()
        {
            Wait.Until(_driver => NextFromModuleCleaningButton.Displayed);
            return this;
        }
        public CreateDGRReportPage ClickNextFromModuleCleaningButton()
        {
            NextFromModuleCleaningButton.Click();
            return this;
        }
        public CreateDGRReportPage WaitForSubmitButton()
        {
            Wait.Until(_driver => SubmitButton.Displayed);
            return this;
        }
        public CreateDGRReportPage ClickSubmitButton()
        {
            SubmitButton.Click();
            return this;
        }
    }
}
