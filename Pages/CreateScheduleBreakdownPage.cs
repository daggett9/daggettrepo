using Autotests.PageObjects;
using Autotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Pages
{
    public class CreateScheduleBreakdownPage : PageObject
    {
        public CreateScheduleBreakdownPage(IWebDriver driver) : base(driver) { }

        public IWebElement BreakdownTab => _driver.FindElement(By.Id("breakdownMaintenance-btn")); //Xpath=//tagname[@attribute='value']

        public IWebElement AlarmType => _driver.FindElement(By.Id("alarmTypeDropBox"));

        public IWebElement AlarmCode => _driver.FindElement(By.Id("alarmCodeDropBox"));

        public IWebElement AssetType => _driver.FindElement(By.CssSelector("span#select2-breakdownAssetType-container+span"));

        public IWebElement ViewListButton => _driver.FindElement(By.XPath(".//button[@class='btn ml-4 active-button nowrap-btn styling-btn-fz14']"));

        public IWebElement AssetIdListWindow => _driver.FindElement(By.Id("assetListFormBreakdownMaintenance"));

        public IWebElement MaintenanceType => _driver.FindElement(By.CssSelector("span#select2-breakdownMaintanceTyleId-container+span"));

        public IWebElement Action => _driver.FindElement(By.CssSelector("span#select2-breakdownMaintanceAction-container+span"));

        public IWebElement StartDate => _driver.FindElement(By.Id("breakdownStartOnDate"));

        public IWebElement EndDate => _driver.FindElement(By.Id("breakdownEndOnDate"));

        public IWebElement StartOnTime => _driver.FindElement(By.Id("breakdownStartOnTime"));

        public IWebElement EndOnTime => _driver.FindElement(By.Id("breakdownEndOnTime"));

        public IWebElement Priority => _driver.FindElement(By.CssSelector("span#select2-breakdownMaintancePriority-container+span"));

        public IWebElement AssigneesEmail => _driver.FindElement(By.CssSelector("span#select2-assigneesEmailIdBreakdown-container+span"));

        public IWebElement Description => _driver.FindElement(By.Id("breakdownDescription"));

        public IWebElement Submit => _driver.FindElement(By.Id("submitBreakdownMaintenance"));

        public IWebElement AssetIDListFormBreakdownMaintenance => _driver.FindElement(By.Id("assetListBreakdownMaintenanceModal"));

        public CreateScheduleBreakdownPage OpenCreateSchedulePage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/MaintenanceManagement/CreateSchedule");
            return this;
        }
        public CreateScheduleBreakdownPage ClickBreakdownTab()
        {
            BreakdownTab.Click();
            return this;
        }
        public CreateScheduleBreakdownPage TypeAlarmType(string AlarmTypeText)
        {
            AlarmType.SendKeys(AlarmTypeText);
            return this;
        }
        public CreateScheduleBreakdownPage TypeAlarmCode(string AlarmCodeText)
        {
            AlarmCode.SendKeys(AlarmCodeText);
            return this;
        }
        public CreateScheduleBreakdownPage SelectFromDD(string CssSelector, string TextValueFromDD)
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
        public CreateScheduleBreakdownPage SelectAssetType()
        {
            AssetType.Click();
            SelectFromDD("li[class*='select2-results__option']", "Inverter");
            return this;
        }
        public CreateScheduleBreakdownPage ClickViewListButton()
        {
            ViewListButton.Click();
            Wait.Until(_driver => AssetIDListFormBreakdownMaintenance.Displayed);
            return this; 
        }
        public CreateScheduleBreakdownPage SelectMaintenanceType()
        {
            MaintenanceType.Click();
            SelectFromDD("li[class*='select2-results__option']", "Servicing");
            return this;
        }
        public CreateScheduleBreakdownPage SelectAction()
        {
            Action.Click();
            SelectFromDD("li[class*='select2-results__option']", "String Voltage");
            return this;
        }
        public CreateScheduleBreakdownPage TypeStartDate(string startDate)
        {
            StartDate.SendKeys(startDate);
            return this;
        }
        public CreateScheduleBreakdownPage TypeStartOnTime(string startTime)
        {
            StartOnTime.SendKeys(startTime);
            return this;
        }
        public CreateScheduleBreakdownPage TypeEndDate(string endDate)
        {
            EndDate.SendKeys(endDate);
            return this;
        }
        public CreateScheduleBreakdownPage TypeEndOnTime(string endTime)
        {
            EndOnTime.SendKeys(endTime);
            return this;
        }
        public CreateScheduleBreakdownPage SelectPriority()
        {
            Priority.Click();
            SelectFromDD("li[class*='select2-results__option']", "Medium");
            return this;
        }
        public CreateScheduleBreakdownPage SelectAssigneesEmail()
        {
            AssigneesEmail.Click();
            SelectFromDD("li[class*='select2-results__option']", "wsmith@gmail.com");
            return this;
        }
        public CreateScheduleBreakdownPage TypeDescription()
        {
            Description.SendKeys("AutoTest_CreateScheduleBreakdown");
            return this;
        }
        public CreateScheduleBreakdownPage ClickSubmitButton()
        {
            Submit.Click();
            return this;
        }
        public CreateScheduleBreakdownPage WaitForPageUpload()
        {
            Wait.Until(_driver => _driver.FindElement(By.XPath("//button[@id='dropdownMenu2']")).Displayed);
            return this;
        }
    }
}
