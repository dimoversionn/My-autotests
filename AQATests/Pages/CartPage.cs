using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace AQATests.Pages
{
    public class CartPage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "a[style='color: inherit;']")]
        public IList<IWebElement> ItemsNames { get; set; }
        //input[name='terms_agreed']
        [FindsBy(How = How.CssSelector, Using = "input[name='terms_agreed']")]
        public IWebElement termsAgreedCheckbox { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "button.btn-success")]
        public IWebElement confirmButton { get; set; }

        public CartPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void CreatingTheOrdeerWithAvailableItems()
        {
            Driver.Navigate().GoToUrl("https://demo.litecart.net/checkout");
            termsAgreedCheckbox.Click();
            confirmButton.Click();
        }
    }
}
