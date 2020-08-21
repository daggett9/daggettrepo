using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Autotests.Pages;
using Autotests.PageObjects;
using System.Configuration;

namespace Autotests
{
    public class BaseTest
    {
        private IWebDriver _driver;

        private ChromeOptions _chromeOptions;

        //DB Connection
        private DataBaseConnection _dbConn;
        public DataBaseConnection DbConn => _dbConn;
        public string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver(ChromeOptions);
                }
                return _driver;
            }
        }
        public ChromeOptions ChromeOptions
        {
            get
            {
                if (_chromeOptions == null)
                {
                    _chromeOptions = new ChromeOptions();
                    _chromeOptions.AddUserProfilePreference("download.default_directory", PageObject.DownloadsFolderPath);
                }
                return _chromeOptions;
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/");
            Driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login("wsmith@gmail.com", "Qwe123!!");
            _dbConn = new DataBaseConnection();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _dbConn.CloseConnection();
            _driver.Quit();
        }
    }
}
