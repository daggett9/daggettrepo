using Autotests.PageObjects;
using Autotests.Tests;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Autotests.Pages
{
    public class CreateSchedulePlannedPage : PageObject
    {
        public CreateSchedulePlannedPage(IWebDriver driver) : base(driver) { }

        public IWebElement AssetType => _driver.FindElement(By.CssSelector("span#select2-plannedAssetType-container+span"));

        public IWebElement ViewListButton => _driver.FindElement(By.XPath(".//button[@class='btn ml-4 active nowrap-btn styling-btn-fz14']"));

        public IWebElement MaintenanceType => _driver.FindElement(By.CssSelector("span#select2-plannedMaintenanceTypeId-container+span"));

        public IWebElement Action => _driver.FindElement(By.CssSelector("span#select2-plannedActionId-container+span"));

        public IWebElement StartDate => _driver.FindElement(By.Id("plannedStartOnDate")); //Xpath=//tagname[@attribute='value']

        public IWebElement EndDate => _driver.FindElement(By.Id("plannedEndOnDate"));

        public IWebElement StartOnTime => _driver.FindElement(By.Id("plannedStartOnTime"));

        public IWebElement EndOnTime => _driver.FindElement(By.Id("plannedEndOnTime"));

        public IWebElement Duration => _driver.FindElement(By.CssSelector("span#select2-plannedActivityDuration-container+span"));

        public IWebElement Frequency => _driver.FindElement(By.CssSelector("span#select2-plannedFrequency-container+span"));

        public IWebElement Priority => _driver.FindElement(By.CssSelector("span#select2-plannedPriority-container+span"));

        public IWebElement AssigneesEmail => _driver.FindElement(By.CssSelector("span#select2-assigneesEmailIdPlanned-container+span"));

        public IWebElement Description => _driver.FindElement(By.Id("plannedDescription"));

        public IWebElement Submit => _driver.FindElement(By.Id("submitPlannedMaintenance"));

        public IWebElement AssetListFormPlannedMaintenance => _driver.FindElement(By.Id("assetListFormPlannedMaintenance"));


        public CreateSchedulePlannedPage OpenCreateSchedulePage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/MaintenanceManagement/CreateSchedule");
            return this;
        }
        public CreateSchedulePlannedPage SelectFromDD(string CssSelector, string TextValueFromDD)
        {
            IList<IWebElement> DDSelection = _driver.FindElements(By.CssSelector(CssSelector));
            foreach (IWebElement element in DDSelection)
            {
                if (element.Text.Equals(TextValueFromDD))
                {
                    element.Click();
                    return this;
                }
            }
            return this;
        }
        public CreateSchedulePlannedPage SelectAssetType()
        {
            AssetType.Click();
            SelectFromDD("li[class*='select2-results__option']", "Inverter");
            return this;
        }
        public CreateSchedulePlannedPage ClickViewListButton()
        {
            ViewListButton.Click();
            Wait.Until(_driver => AssetListFormPlannedMaintenance.Displayed);
            return this;
        }
        public CreateSchedulePlannedPage ClickCloseViewListButton()
        {
            IWebElement CloseViewListButton = _driver.FindElement(By.ClassName("btn confirm-button my-1"));
            CloseViewListButton.Click();
            return this;
        }
        public CreateSchedulePlannedPage SelectMaintenanceType()
        {
            MaintenanceType.Click();
            SelectFromDD("li[class*='select2-results__option']", "Servicing");
            return this;
        }
        public CreateSchedulePlannedPage SelectAction()
        {
            Action.Click();
            SelectFromDD("li[class*='select2-results__option']", "String Voltage");
            return this;
        }
        public CreateSchedulePlannedPage TypeStartDate(string startDate)
        {
            StartDate.SendKeys(startDate);
            return this;
        }
        public CreateSchedulePlannedPage TypeStartOnTime(string startTime)
        {
            StartOnTime.SendKeys(startTime);
            return this;
        }
        public CreateSchedulePlannedPage TypeEndDate(string endDate)
        {
            EndDate.SendKeys(endDate);
            return this;
        }
        public CreateSchedulePlannedPage TypeEndOnTime(string endTime)
        {
            EndOnTime.SendKeys(endTime);
            return this;
        }
        public CreateSchedulePlannedPage SelectDuration()
        {
            Duration.Click();
            SelectFromDD("li[class*='select2-results__option']", "1 hour");
            return this;
        }
        public CreateSchedulePlannedPage SelectFrequency()
        {
            Frequency.Click();
            SelectFromDD("li[class*='select2-results__option']", "Yearly");
            return this;
        }
        public CreateSchedulePlannedPage SelectPriority()
        {
            Priority.Click();
            SelectFromDD("li[class*='select2-results__option']", "Medium");
            return this;
        }
        public CreateSchedulePlannedPage SelectAssigneesEmail()
        {
            AssigneesEmail.Click();
            SelectFromDD("li[class*='select2-results__option']", "wsmith@gmail.com");
            return this;
        }
        public CreateSchedulePlannedPage TypeDescription()
        {
            Description.SendKeys("AutoTest_CreateSchedulePlanned");
            return this;
        }
        public CreateSchedulePlannedPage ClickSubmitButton()
        {
            Submit.Click();
            return this;
        }
        public CreateSchedulePlannedPage WaitForPageUpload()
        {
            Wait.Until(_driver => _driver.FindElement(By.XPath("//button[@id='dropdownMenu2']")).Displayed);
            return this;
        }
    }
}
