using ImmedisSiteTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace ImmedisSiteTest.Tests;

public class SignUpPageTests
{
    private WebDriver driver;
    private SignUpPage page;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        page = new SignUpPage(driver);
    }

    [Test]
    public void TestWithInvalidDetails()
    {
        page.OpenPage();
        var result = page.LoginTest("simeonntodorov@gmail.com", "HelloImmedis");
        Assert.That(result, Is.EqualTo("Incorrect email or password"));
        driver.Quit();
    }

}