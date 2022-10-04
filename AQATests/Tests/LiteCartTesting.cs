using AQATests.Base;
using AQATests.Pages;
using NUnit.Framework;
using System;
using System.Threading;

namespace AQATests
{
    
    public class LiteCartTesting : TestBase
    {
        [Test]
        public void WhenLoginWithValidUserMailAndPassword_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.LoginWithCorrectUserMailAndPassword("user@email.com", "demo");
            mainPage.CheckThatAlertMessageContainsText("logged in as John Doe.");
        }

        [Test]
        public void WhenLoginWithValidUserMailAndPassword_AndLogout_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.LoginWithCorrectUserMailAndPassword("user@email.com", "demo");
            mainPage.LogoutFromAccount();
            mainPage.CheckThatAlertMessageContainsText("You are now logged out.");
        }

        [Test]
        public void WhenAddingPurpleDuckUsingPrewievMenu_PurpleDuckShouldAddToTheCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.AddPurpleDuckToCartUsingPrewiev();
            mainPage.CheckThatCartContainsItem("Purple Duck");
        }

        [Test]
        public void WhenAddingBlueDuck_ItShouldAddToTheCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.AddDuckToCart("Blue Duck");
            mainPage.CheckThatCartContainsItem("Blue Duck");
        }

        [Test]
        public void WhenCreatingTheOrder_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(driver);
            CartPage cartPage = new CartPage(driver);
            mainPage.LoginWithCorrectUserMailAndPassword("user@email.com", "demo");
            mainPage.AddDuckToCart("Blue Duck");
            cartPage.CreatingTheOrdeerWithAvailableItems();
            mainPage.CheckThatSuccessOrderMessageContainsText("was completed successfully!");
        }
        [Test]
        public void WhenCreatingTheOrder_OrderStatusInOrdersListShouldBeReady()
        {
            MainPage mainPage = new MainPage(driver);
            CartPage cartPage = new CartPage(driver);
            OrderHistoryPage orderHistoryPage = new OrderHistoryPage(driver);
            mainPage.LoginWithCorrectUserMailAndPassword("user@email.com", "demo");
            mainPage.AddDuckToCart("Blue Duck");
            cartPage.CreatingTheOrdeerWithAvailableItems();
            orderHistoryPage.CheckOrderStatusInOrderList("Ready");
        }


    }
}