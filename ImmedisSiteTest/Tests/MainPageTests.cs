using NUnit.Framework;
using OpenQA.Selenium;
using ImmedisSiteTest.Pages;
using OpenQA.Selenium.Chrome;

namespace ImmedisSiteTest.Tests
{
    public class MainPageTests
    {
        private WebDriver driver;
        private MainPage page;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            page = new MainPage(driver);
        }
        [Test]
        public void MainPageTest()
        {
            page.OpenPage();
            var result = page.SendMessage();
            Assert.That(result, Is.EqualTo("This field is required."));
            driver.Quit();
        }
    }
}
