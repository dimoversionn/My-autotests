using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQATests.Pages
{
    class OrderHistoryPage
    {
        public IWebDriver Driver;
        public OrderHistoryPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]//td[@class='text-end'][1]")]
        public IWebElement firstOrderAmount { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]//td[@class='text-center']")]
        public IWebElement firstOrderStatus { get; set; }

        public void CheckOrderStatusInOrderList(string expectedOrderStatus)
        {
            Driver.Navigate().GoToUrl("https://demo.litecart.net/order_history");
            string actualOrderStatus = firstOrderStatus.Text; 
            Assert.AreEqual(expectedOrderStatus, actualOrderStatus);
        }
    }
}
