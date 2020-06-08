using Autotests.Pages;
using NUnit.Framework;

namespace Autotests.Tests
{
    [TestFixture]
    class CreateEscalationMatrixTest : BaseTest
    {
        [Test, Category("MaintenancePlanner")]

        public void CreateEscalationMatrixWithEmailOnly()
        {
            EscalationMatrixPage escalationMatrixPage = new EscalationMatrixPage(Driver);

            escalationMatrixPage
                .OpenEscalationMatrixPage()
                .ClickAddContactButton()
                .ClickEmailIdField()
                .TypeEmailId("fromAuto@test.com")
                .ClickPencilIcon()
                .ClickUpdateButton()
                .WaitForPageUpload();
            string URL = Driver.Url;
            Assert.AreEqual(URL, "https://solarostest.mahindrateqo.com/MaintenanceManagement/MaintenancePlanner");
        }

        [Test, Category("MaintenancePlanner")]

        public void CreateEscalationMatrixWithSMSContactOnly()
        {
            EscalationMatrixPage escalationMatrixPage = new EscalationMatrixPage(Driver);

            escalationMatrixPage
                .OpenEscalationMatrixPage()
                .ClickAddContactButton()
                .ClickSMSContactField()
                .TypeSMSContact("123456789")
                .ClickPencilIcon()
                .ClickUpdateButton()
                .WaitForPageUpload();
            string URL = Driver.Url;
            Assert.AreEqual(URL, "https://solarostest.mahindrateqo.com/MaintenanceManagement/MaintenancePlanner");
        }

        [Test, Category("MaintenancePlanner")]

        public void CreateEscalationMatrixWithEmailAndSMSContact()
        {
            EscalationMatrixPage escalationMatrixPage = new EscalationMatrixPage(Driver);
            
            escalationMatrixPage
                .OpenEscalationMatrixPage()
                .ClickAddContactButton()
                .ClickEmailIdField()
                .TypeEmailId("fromAuto@test.com")
                .ClickSMSContactField()
                .TypeSMSContact("123456789")
                .ClickPencilIcon()
                .ClickUpdateButton()
                .WaitForPageUpload();
            string URL = Driver.Url;
            Assert.AreEqual(URL, "https://solarostest.mahindrateqo.com/MaintenanceManagement/MaintenancePlanner");
        }
    }
}
