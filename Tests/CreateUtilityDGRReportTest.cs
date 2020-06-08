using Autotests.Pages;
using NUnit.Framework;

namespace Autotests.Tests
{
    class CreateUtilityDGRReportTest : BaseTest
    {
        [Test, Category("DGR Reports")]

        public void CreateNewUtilityDGRReportTest()
        {
            CreateDGRReportPage createDGRReportPage = new CreateDGRReportPage(Driver);

            createDGRReportPage
                .OpenCreateDGRReportPage()
                .ClickDateField()
                .DeleteDefaultDate()
                .TypeDate()
                .ClickLossOfInsolationDueToGridFailureField()
                .TypeLossOfInsolationDueToGridFailure()
                .ClickNextButton()
                .WaitForNextFromManualEntryButton()
                .ClickNextFromManualEntryButton()
                .WaitForNextFromModuleCleaningButton()
                .ClickNextFromModuleCleaningButton()
                .WaitForSubmitButton()
                .ClickSubmitButton();
        }
    }
}
