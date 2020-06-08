using Autotests.Pages;
using NUnit.Framework;

namespace Autotests.Tests
{
    class MaintenanceScheduleDownloadPDFTest : BaseTest
    {
        [Test, Category("MaintenancePlanner")]

        public void MaintenanceScheduleDownloadPDF()
        {
            MaintenancePlannerOverviewPage maintenancePlannerOverviewPage = new MaintenancePlannerOverviewPage(Driver);


            maintenancePlannerOverviewPage
                .OpenMaintenancePlannerOverviewPage()
                .WaitForLoaderDisappear()
                .ClickDownloadButton()
                .ClickDownloadPDFButton()
                .WaitForFileDownload()
                .DeleteTheFile();
        }
    }
}
