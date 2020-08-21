using Autotests.DBQueries;
using Autotests.Models;
using Autotests.PageObjects;
using Autotests.Pages;
using NUnit.Framework;
using System;
using System.Configuration;

namespace Autotests.Tests
{
    [TestFixture]
    class UploadDocumentManualTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            //ManageFoldersPage manageFoldersPage = new ManageFoldersPage(Driver);

            //manageFoldersPage
            //    .OpenManageFoldersPage()
            //    .ClickAddMainFolderButton()
            //    .TypeNewFolderName()
            //    .ClickSortingArrows()
            //    .ClickSaveChangesAndCloseButton();
            //DataBaseConnection dataBaseConnection = new DataBaseConnection();
            //dataBaseConnection.Connection.Open();

            Folder newFolder = new Folder
            {
                FolderName = "ParentFolderFromAutoTest",
                SiteId = 1,
                Createdate = DateTime.Now
            };
            FolderRepository folderRepository = new FolderRepository(connString);
            folderRepository.CreateAndGetId(newFolder);
        }

        [Test, Category("Plant Documentation")]
        public void UploadDocumentManualFromComputer()
        {
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);
            FolderRepository folderRepository = new FolderRepository(connString);

            uploadFileManualEntryPage
                .OpenUploadFilePage()
                .ClickChooseFileButton();
            uploadFromWindowPage
               .SendPathManualEntry("ManualEntryUploadedFileJPG.jpg");
            uploadFileManualEntryPage
                .SelectParentFolderToSave()
                .TypeDocumentName("ManualEntryfromAuto")
                .TypeDescription()
                .TypeStartDate()
                .TypeEndDate()
                .ClickUploadButton()
                .WaitForPageUpload();
            string FolderId = folderRepository
                .GetIdByFolderName().ToString();
            plantDocumentationDocumentsPage
                .ClickParentFolderButton(FolderId);
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckDocumentExistence("ManualEntryfromAuto"));
        }

        [Test, Category("Plant Documentation")]
        public void UploadDocumentManualFromOneDrive()
        {
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);
            FolderRepository folderRepository = new FolderRepository(connString);
            OneDriveLoginPage oneDriveLoginPage = new OneDriveLoginPage(Driver);
            OneDriveListOfFilesPage oneDriveListOfFilesPage = new OneDriveListOfFilesPage(Driver);

            uploadFileManualEntryPage
                .OpenUploadFilePage()
                .ClickChooseFileButton();
            uploadFromWindowPage
                .ClearOneDriveCookies()
                .ClickOneDriveIcon()
                .WaitForPageUpload();
            oneDriveLoginPage
                .EnterMicrosoftLogin()
                .ClickNextButton()
                .EnterPassword()
                .ClickSignInButton();
            oneDriveListOfFilesPage
                .ClickPlusIcon()
                .ClickFileCheckbox()
                .ClickSelectButton();
            uploadFileManualEntryPage
                .SelectParentFolderToSave()
                .TypeDocumentName("ManualEntryfromAuto")
                .TypeDescription()
                .TypeStartDate()
                .TypeEndDate()
                .ClickUploadButton()
                .WaitForPageUpload();
            string FolderId = folderRepository
                .GetIdByFolderName().ToString();
            plantDocumentationDocumentsPage
                .ClickParentFolderButton(FolderId);
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckDocumentExistence("ManualEntryfromAuto"));
        }

        [TearDown]
        public void TearDown()
        {
            //ManageFoldersPage manageFoldersPage = new ManageFoldersPage(Driver);

            //manageFoldersPage
            //    .OpenManageFoldersPage()
            //    .ClickDeleteButton()
            //    .ClickConfirmDeleteButton();        
            FolderRepository folderRepository = new FolderRepository(connString);
            folderRepository.Delete("ParentFolderFromAutoTest");
        }
    }
}