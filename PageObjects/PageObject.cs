using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Autotests.PageObjects
{
    public class PageObject
    {

        protected readonly IWebDriver _driver;

        private WebDriverWait _waiter;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        public WebDriverWait Wait => _waiter ?? (_waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(15)));

        public static string OutPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        public static string DownloadsFolder => Path.Combine(OutPutDirectory, "Downloads");
        public static string DownloadsFolderPath => new Uri(DownloadsFolder).LocalPath;
        public static string FilesFolder => Path.Combine(OutPutDirectory, "Files");
        public static string FilesFolderPath => new Uri(FilesFolder).LocalPath;


        public string SetFilePath(string fileName)
        {
            string FileName = Path.Combine(FilesFolderPath, fileName);
            string FilePath = new Uri(FileName).LocalPath;
            return FilePath;
        }
    }
}
