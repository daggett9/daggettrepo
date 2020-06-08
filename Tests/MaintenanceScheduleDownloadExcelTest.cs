using Autotests.Pages;
using NUnit.Framework;

namespace Autotests.Tests
{
    class MaintenanceScheduleDownloadExcelTest : BaseTest
    {
        [Test, Category("MaintenancePlanner")]

        public void MaintenanceScheduleDownloadExcel()
        {
            MaintenancePlannerOverviewPage maintenancePlannerOverviewPage = new MaintenancePlannerOverviewPage(Driver);


            maintenancePlannerOverviewPage
                .OpenMaintenancePlannerOverviewPage()
                .WaitForLoaderDisappear()
                .ClickDownloadButton()
                .ClickDownloadExcelButton()
                .WaitForFileDownload()
                .DeleteTheFile();
        }
    }
}
