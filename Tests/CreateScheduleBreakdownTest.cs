using Autotests.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Tests
{
    class CreateScheduleBreakdownTest : BaseTest
    {
        [Test, Category("MaintenancePlanner")]
        public void CreateNewScheduleBreakdownTest()
        {
            CreateScheduleBreakdownPage createScheduleBreakdownPage = new CreateScheduleBreakdownPage(Driver); // инициализируем обращение к эл-м страницы Create Schedule Breakdown
            AssetIdListWindowPage assetIdListWindowPage = new AssetIdListWindowPage(Driver); // инициализируем обращение к эл-м окна Asset ID

       
            createScheduleBreakdownPage
                .OpenCreateSchedulePage()
                .ClickBreakdownTab()
                .TypeAlarmType("auto123")
                .TypeAlarmCode("auto456")
                .SelectAssetType()
                .ClickViewListButton();
            assetIdListWindowPage
                .SelectFirstAssetId()
                .SelectSecondAssetId()
                .ClickSaveAndCloseBreakdownButton();
            createScheduleBreakdownPage
                .SelectMaintenanceType()
                .SelectAction()
                .TypeStartDate("02/27/2020")
                .TypeStartOnTime("18:07:43")
                .TypeEndDate("02/28/2020")
                .TypeEndOnTime("19:07:43")
                .SelectPriority()
                .SelectAssigneesEmail()
                .TypeDescription()
                .ClickSubmitButton()
                .WaitForPageUpload();
            string URL = Driver.Url;
            Assert.AreEqual(URL, "https://solarostest.mahindrateqo.com/MaintenanceManagement/MaintenancePlanner");
        }

    }
}
