using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ImmedisSiteTest.Pages
{
    public class MainPage
    {
        IWebDriver driver;
        public MainPage(WebDriver driver)
        {
            this.driver = driver;
        }
        
        public IWebElement solutionBtn => driver.FindElement(By.XPath("(//a[@href='javascript:;'])[1]"));
        public IWebElement oneViewConnect => driver.FindElement(By.XPath("(//span[@class='description'])[2]"));
        public IWebElement getInTouch => driver.FindElement(By.XPath("(//a[contains(@class,'button')])[5]"));
        public IWebElement firstName => driver.FindElement(By.Id("forminator-field-name-1"));
        public IWebElement lastName => driver.FindElement(By.Id("forminator-field-name-2"));
        public IWebElement email => driver.FindElement(By.Id("forminator-field-email-1"));
        public IWebElement company => driver.FindElement(By.Id("forminator-field-text-1"));
        public IWebElement phone => driver.FindElement(By.Id("forminator-field-phone-1"));
        public IWebElement jobFunction => driver.FindElement(By.Id("forminator-form-54__field--select-1_6508a257e8c99"));
        public IWebElement numberOfEmployees => driver.FindElement(By.Id("forminator-form-54__field--select-2_6508a257e8c99"));
        public IWebElement numberOfLocations => driver.FindElement(By.Id("forminator-form-54__field--select-3_6508a257e8c99"));
        public IWebElement sendMessage => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement errorMsg => driver.FindElement(By.XPath("(//span[@aria-hidden='true'])[1]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl("https://immedis.com");
        }

        public string SendMessage()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions.MoveToElement(solutionBtn).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(oneViewConnect)).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;     
            js.ExecuteScript("window.scrollBy(0, 1600);");
            Thread.Sleep(1000);
            getInTouch.Click();
            firstName.SendKeys("Simeon");
            lastName.SendKeys("Todorov");
            email.SendKeys("simeonntodorov@gmail.com");
            company.SendKeys("Imedis");
            phone.SendKeys("00359878618801");
            js.ExecuteScript("window.scrollBy(0, 900);");
            Thread.Sleep(1000);
            sendMessage.Click();
            return errorMsg.Text;
        }




    }



}
