using Autotests.Pages;
using NUnit.Framework;
using Autotests.PageObjects;

namespace Autotests.Tests
{
    [TestFixture]
    class UploadDocumentBatchTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            ManageFoldersPage manageFoldersPage = new ManageFoldersPage(Driver);

            manageFoldersPage
                .OpenManageFoldersPage()
                .ClickAddMainFolderButton()
                .TypeNewFolderName()
                .ClickSortingArrows()
                .ClickSaveChangesAndCloseButton();
        }
        [Test, Category("Plant Documentation")]
        public void UploadDocumentBatchFromComputer()
        {
            UploadFileBatchPage uploadFileBatchPage = new UploadFileBatchPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);


            uploadFileBatchPage
                .OpenUploadFilePage()
                .ClickBatchUploadTab()
                .ConfirmLeavePageWindow()
                .SelectParentFolderToSave()
                .ClickChooseFileButton();
            uploadFromWindowPage
                .SendPathBatch("ManualEntryUploadedFileJPG.jpg");
            uploadFileBatchPage
                .ClickUploadButton()
                .WaitForPageUpload();
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckFolderExistence("ParentFolderFromAutoTest"));
        }

        [TearDown]
        public void TearDown()
        {
            ManageFoldersPage manageFoldersPage = new ManageFoldersPage(Driver);

            manageFoldersPage
                .OpenManageFoldersPage()
                .ClickDeleteButton()
                .ClickConfirmDeleteButton();
        }
    }
}
