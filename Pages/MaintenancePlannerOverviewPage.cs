using Autotests.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.IO;

namespace Autotests.Pages
{
    class MaintenancePlannerOverviewPage : PageObject
    {
        public MaintenancePlannerOverviewPage(IWebDriver driver) : base(driver) { }

        public IWebElement DownloadButton => _driver.FindElement(By.XPath("//button[@id='dropdownMenu2']"));

        public IWebElement DownloadExcelButton => _driver.FindElement(By.Id("download-excel-file"));

        public IWebElement DownloadPDFButton => _driver.FindElement(By.Id("download-pdf-file"));

        public IWebElement LoaderIcon => _driver.FindElement(By.Id("main-loader"));


        public MaintenancePlannerOverviewPage OpenMaintenancePlannerOverviewPage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/MaintenanceManagement/MaintenancePlanner");
            return this;
        }
        public MaintenancePlannerOverviewPage WaitForLoaderDisappear()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("main-loader")));
            return this;
        }
        public MaintenancePlannerOverviewPage ClickDownloadButton()
        {
            DownloadButton.Click();
            return this;
        }
        public MaintenancePlannerOverviewPage ClickDownloadExcelButton()
        {
            Wait.Until(_driver => DownloadExcelButton.Displayed);
            DownloadExcelButton.Click();
            return this;
        }
        public MaintenancePlannerOverviewPage ClickDownloadPDFButton()
        {
            DownloadPDFButton.Click();
            return this;
        }
        public MaintenancePlannerOverviewPage WaitForFileDownload()
        {
            Thread.Sleep(10000);
            return this;
        }
        public MaintenancePlannerOverviewPage DeleteTheFile()
        {
            string[] Files = Directory.GetFiles(DownloadsFolderPath);
            foreach (string file in Files)
            {
                if (Files.Length == 1)
                    File.Delete(file);
            }
            return this;
        }
    }
}
