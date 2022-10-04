using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace AQATests.Pages
{
    class ItemPage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "button[name='add_cart_product']")]
        public IWebElement addtoCartButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement selecter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement largeSelector { get; set; }



        public ItemPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

    }
}
