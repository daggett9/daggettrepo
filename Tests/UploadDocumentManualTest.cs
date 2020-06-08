using Autotests.DBQueries;
using Autotests.Models;
using Autotests.PageObjects;
using Autotests.Pages;
using NUnit.Framework;
using System;
using System.Data;
using System.Windows;

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

            //private static readonly string connectionString = "Server = 13.233.48.253; Database = MPulseERP; User Id = mpulse; password = MPul53p@$$";
            //FolderRepository folderRepository = new FolderRepository(connectionString);

            Folder newFolder = new Folder
            {
                FolderName = "ParentFolderFromAutoTest",
                SiteId = 1,
                Createdate = DateTime.Now
            };

            FolderRepository folderRepository = new FolderRepository("Server = 13.233.48.253; Database = MPulseERP; User Id = mpulse; password = MPul53p@$$");
            folderRepository.CreateAndGetId(newFolder);
        }


        [Test, Category("Plant Documentation")]
        public void UploadDocumentManualFromComputer()
        {
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);

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
            Assert.AreEqual(true, plantDocumentationDocumentsPage.CheckDocumentExistence("ManualEntryfromAuto"));
        }

        [Test, Category("Plant Documentation")]
        public void UploadDocumentManualFromOneDrive()
        {
            UploadFileManualEntryPage uploadFileManualEntryPage = new UploadFileManualEntryPage(Driver);
            UploadFromWindowPage uploadFromWindowPage = new UploadFromWindowPage(Driver);
            PlantDocumentationDocumentsPage plantDocumentationDocumentsPage = new PlantDocumentationDocumentsPage(Driver);

            uploadFileManualEntryPage
                .OpenUploadFilePage()
                .ClickChooseFileButton();
            uploadFromWindowPage
                .ClearOneDriveCookies()
                .ClickOneDriveIcon();
            uploadFileManualEntryPage
                .SelectParentFolderToSave()
                .TypeDocumentName("ManualEntryfromAuto")
                .TypeDescription()
                .TypeStartDate()
                .TypeEndDate()
                .ClickUploadButton()
                .WaitForPageUpload();
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
            //DocumentationRepository documentationRepository = new DocumentationRepository(DbConn);
            //documentationRepository.DeleteParentFolder();
            //DataBaseConnection dataBaseConnection = new DataBaseConnection();
            //dataBaseConnection.Connection.Close();
            FolderRepository folderRepository = new FolderRepository("Server = 13.233.48.253; Database = MPulseERP; User Id = mpulse; password = MPul53p@$$");
            folderRepository.Delete("ParentFolderFromAutoTest");
        }
    }
}