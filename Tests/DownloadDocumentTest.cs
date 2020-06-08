using Autotests.Pages;
using NUnit.Framework;
using Autotests.PageObjects;

namespace Autotests.Tests
{
    [TestFixture]
    class DownloadDocumentTest : BaseTest
    {
        [OneTimeSetUp]
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

        public void DownloadJPGFile()
        {
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);

            uploadFileManualEntryPage
                .OpenUploadFilePage()
                .ClickChooseFileButton();
            uploadFromWindowPage
                .SendPathManualEntry("ManualEntryUploadedFileJPG.jpg");
            uploadFileManualEntryPage
                .SelectParentFolderToSave()
                .TypeDocumentName("JPGFileToBeDownload")
                .TypeDescription()
                .TypeStartDate()
                .TypeEndDate()
                .ClickUploadButton()
                .WaitForPageUpload();
            plantDocumentationDocumentsPage
                .ClickSearchField()
                .TypeSearchRequest("JPGFileToBeDownload")
                .WaitForSearchExecution()
                .ClickJPGFileIcon()
                .WaitForFileDownload()
                .CheckDownloadedFileExists(PageObject.DownloadsFolderPath + "//ManualEntryUploadedFileJPG.jpg");
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckDownloadedFileExists(PageObject.DownloadsFolderPath + "//ManualEntryUploadedFileJPG.jpg"));
        }

        [Test, Category("Plant Documentation")]
        public void DownloadXMLFile()
        {
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);


            uploadFileManualEntryPage
                .OpenUploadFilePage()
                .ClickChooseFileButton();
            uploadFromWindowPage
                .SendPathManualEntry("ManualEntryUploadedFileXLSM.xlsm");
            uploadFileManualEntryPage
                .SelectParentFolderToSave()
                .TypeDocumentName("XLSMFileToBeDownload")
                .TypeDescription()
                .TypeStartDate()
                .TypeEndDate()
                .ClickUploadButton()
                .WaitForPageUpload();
            plantDocumentationDocumentsPage
                .ClickSearchField()
                .TypeSearchRequest("XLSMFileToBeDownload")
                .WaitForSearchExecution()
                .ClickJPGFileIcon()
                .WaitForFileDownload()
                .CheckDownloadedFileExists(PageObject.DownloadsFolderPath + "//ManualEntryUploadedFileXLSM.xlsm");
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckDownloadedFileExists(PageObject.DownloadsFolderPath + "//ManualEntryUploadedFileXLSM.xlsm"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ManageFoldersPage manageFoldersPage = new ManageFoldersPage(Driver);

            manageFoldersPage
                .ClearDownloads()
                .OpenManageFoldersPage()
                .ClickDeleteButton()
                .ClickConfirmDeleteButton();
        }
    }
}
