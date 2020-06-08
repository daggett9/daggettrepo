using Autotests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Pages
{
    class EscalationMatrixPage : PageObject
    {
        public EscalationMatrixPage(IWebDriver driver) : base(driver) { }
        public IWebElement HighTabButton => _driver.FindElement(By.XPath("//a[@href='#High']")); //Xpath=//tagname[@attribute='value']

        public IWebElement MediumTabButton => _driver.FindElement(By.XPath("//a[@href='#Medium']"));

        public IWebElement LowTabButton => _driver.FindElement(By.XPath("//a[@href='#Low']"));
        ////thead[@itemname='EscalationMatrixViewModel.EscalationLevels']//h6[@inputname='Escalation Level - ' and(contains(text(),'Escalation Level - 1'))]//button[contains(@onclick='addNewEscalationContact(level0, 0)']
        public IWebElement AddContactButton => _driver.FindElement(By.XPath("//button[@onclick='addNewEscalationContact(level0, 0)']"));

        public IWebElement AddedActiveRow => _driver.FindElement(By.XPath("//tr[@class='contact-block active-row contact-block-custom']"));

        public IWebElement EmailField => _driver.FindElement(By.XPath("//tr[@class='contact-block active-row contact-block-custom']//input[@inputname='Email']"));

        public IWebElement SMSContactField => _driver.FindElement(By.XPath("//tr[@class='contact-block active-row contact-block-custom']//input[@inputname='SMSContact']"));

        public IWebElement PencilIcon => _driver.FindElement(By.XPath("//tr[@class='contact-block active-row contact-block-custom']//button[@class='custom-table-button icon-edit']"));

        public IWebElement UpdateButton => _driver.FindElement(By.XPath("//button[@onclick='updateEscalation()']"));


        public EscalationMatrixPage OpenEscalationMatrixPage()
        {
            _driver.Navigate().GoToUrl("https://solarostest.mahindrateqo.com/MaintenanceManagement/EscalationMatrix");
            Wait.Until(_driver => AddContactButton.Displayed);
            return this;
        }
        public EscalationMatrixPage ClickAddContactButton()
        {
            AddContactButton.Click();
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            Wait.Until(_driver => _driver.FindElements(By.XPath("//tr[@class='contact-block active-row contact-block-custom']//input[@inputname='Email']")).Any() == true);
            return this;
        }
        public EscalationMatrixPage ClickEmailIdField()
        {
            EmailField.Click();
            return this;
        }
        public EscalationMatrixPage ClickSMSContactField()
        {
            SMSContactField.Click();
            return this;
        }
        public EscalationMatrixPage TypeEmailId(string EmailId)
        {
            EmailField.SendKeys(EmailId);
            return this;
        }
        public EscalationMatrixPage TypeSMSContact(string SMSContact)
        {
            SMSContactField.SendKeys(SMSContact);
            return this;
        }
        public EscalationMatrixPage ClickPencilIcon()
        {
            PencilIcon.Click();
            return this;
        }
        public EscalationMatrixPage ClickUpdateButton()
        {
            UpdateButton.Click();
            return this;
        }
        public EscalationMatrixPage WaitForPageUpload()
        {
            Wait.Until(_driver => _driver.FindElement(By.XPath("//button[@id='dropdownMenu2']")).Displayed);
            return this;
        }
    }
}