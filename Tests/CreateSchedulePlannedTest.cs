using Autotests.Pages;
using NUnit.Framework;

namespace Autotests.Tests
{
    public class CreateSchedulePlannedTest : BaseTest
    {
        [Test, Category("MaintenancePlanner")]
        public void CreateNewSchedulePlannedTest()
        {
            CreateSchedulePlannedPage createSchedulePlanned = new CreateSchedulePlannedPage(Driver); // инициализируем обращение к эл-м страницы Create Schedule Planned
            AssetIdListWindowPage assetIdListWindowPage = new AssetIdListWindowPage(Driver); // инициализируем обращение к эл-м окна Asset ID


            createSchedulePlanned
                .OpenCreateSchedulePage()
                .SelectAssetType()
                .ClickViewListButton();
            assetIdListWindowPage
                .SelectFirstAssetId()
                .SelectSecondAssetId()
                .ClickSaveAndClosePlannedButton();
            createSchedulePlanned
                .SelectMaintenanceType()
                .SelectAction()
                .TypeStartDate("02/27/2020")
                .TypeStartOnTime("18:07:43")
                .TypeEndDate("02/28/2020")
                .TypeEndOnTime("19:07:43")
                .SelectDuration()
                .SelectFrequency()
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
