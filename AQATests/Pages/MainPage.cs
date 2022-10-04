using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;



namespace AQATests.Pages
{
    public class MainPage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "li.account.dropdown a[href='#']")]
        public IWebElement signInButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//li[@class='account dropdown open']//li[3]")]
        public IWebElement logoutButton { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement email { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='login' and text()='Sign In']")]
        private IWebElement login { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main .alert")]
        public IWebElement alert { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-name='Purple Duck']")]
        public IWebElement purpleDuckItem { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@class='preview btn btn-default btn-sm'][contains(@data-target, 'purple-duck')]")]
        public IWebElement purpleDuckPrewievButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@name='add_cart_product']")]
        public IWebElement addToCartInPrewievButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "div#cart")]
        public IWebElement cartButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "div[aria-label='Close']")]
        public IWebElement closeItemPrewievButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "div.badge.quantity")]
        public IWebElement CartHasItemAlert { get; set; }
        //h4.name
        [FindsBy(How = How.CssSelector, Using = "h4.name")]
        public IList<IWebElement> allItemTitles { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='decline_cookies']")]
        public IWebElement declineCookiesButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "h1.title")]
        public IWebElement successOrderMessage { get; set; }

        public MainPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void CheckThatAlertMessageContainsText(string message)
        {
            Assert.That(alert.Text.Contains(message));
        }

        public MainPage LoginWithCorrectUserMailAndPassword(string userMail, string pwd)
        {

            signInButton.Click();
            email.Clear();
            email.SendKeys(userMail);

            password.Clear();
            password.SendKeys(pwd);

            login.Click();
            return new MainPage(Driver);
        }

        public MainPage LogoutFromAccount()
        {

            signInButton.Click();
            logoutButton.Click();
            return new MainPage(Driver);
        }


        public MainPage AddPurpleDuckToCartUsingPrewiev()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(purpleDuckItem).Build().Perform();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='preview btn btn-default btn-sm'][contains(@data-target, 'purple-duck')]")));

            action.MoveToElement(purpleDuckPrewievButton).Build().Perform();
            purpleDuckPrewievButton.Click();
            addToCartInPrewievButton.Click();
            closeItemPrewievButton.Click();
            return new MainPage(Driver);
        }
        

        public void CheckThatCartContainsItem(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.badge.quantity")));
            cartButton.Click();
            CartPage cartPage = new CartPage(Driver);
            string text = "no items";
            foreach (var item in cartPage.ItemsNames)
            {
                if (item.Text == itemName)
                {
                    text = item.Text;
                }
            }
             
            Assert.That(text == itemName);
        }

        public MainPage AddDuckToCart(string itemName)
        {
            declineCookiesButton.Click();
            foreach (var item in allItemTitles)
            {
                if (item.Text == itemName)
                {
                    item.Click();
                    break;
                }
            }

            ItemPage itemPage = new ItemPage(Driver);
            itemPage.addtoCartButton.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.badge.quantity")));
            Driver.Navigate().Back();
            return new MainPage(Driver);
        }

        public void CheckThatSuccessOrderMessageContainsText(string message)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.title")));
            string actualMessage = successOrderMessage.Text;
            Assert.That(successOrderMessage.Text.Contains(message));
        }




    }
}
