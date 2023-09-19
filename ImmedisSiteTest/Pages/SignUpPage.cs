using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImmedisSiteTest.Pages
{
    public class SignUpPage
    {
        IWebDriver driver;

        public SignUpPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement emailField => driver.FindElement(By.Id("email"));
        public IWebElement nextBtn => driver.FindElement(By.XPath("//span[contains(.,'Next')]"));
        public IWebElement passwordField => driver.FindElement(By.Id("password"));
        public IWebElement loginBtn => driver.FindElement(By.XPath("//span[contains(.,'Log in')]"));
        public IWebElement errorMsg => driver.FindElement(By.XPath("//span[@class='ng-tns-c122-1']"));
        public IWebElement acceptBtn => driver.FindElement(By.XPath("//span[contains(.,'Accept')]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl("https://portal.immedis.com/#/account/login");
        }

        public string LoginTest(string email, string password)
        {
            emailField.SendKeys(email);
            nextBtn.Click();
            passwordField.SendKeys(password);
            loginBtn.Click();
            return errorMsg.Text;
        }

    }
}