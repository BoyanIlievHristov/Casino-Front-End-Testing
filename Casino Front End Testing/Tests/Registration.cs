using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Support.UI;

namespace Casino_Front_End_Testing
{
    public class Registration
    {
        private WebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://moneygaming.qa.gameaccount.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        //Arrange
        public IWebElement JoinNowButton => driver.FindElement(By.CssSelector(".newUser.green"));
        public IWebElement Title => driver.FindElement(By.Id("title"));
        public IWebElement FirstName => driver.FindElement(By.Id("forename"));
        public IWebElement LastName => driver.FindElement(By.XPath("//input[@name='map(lastName)']"));
        public IWebElement Checkbox => driver.FindElement(By.Id("checkbox"));
        public IWebElement SubmitRegistrationButton => driver.FindElement(By.Id("form"));
        public IWebElement DoB_error => driver.FindElement(By.XPath("//label[@for='dob']"));

        //Act
        [TestCase("Mr", "Boyan", "Hristov")]
        public void TestRegistration(string titleValue, string firstNameValue, string lastNameValue)
        {
            JoinNowButton.Click();
            SelectElement titleSelect = new SelectElement(Title);
            titleSelect.SelectByValue(titleValue);
            FirstName.SendKeys(firstNameValue);
            LastName.SendKeys(lastNameValue);
            Checkbox.Click();
            SubmitRegistrationButton.Click();

            //Assert
            Assert.That(DoB_error.Text, Is.EqualTo("This field is required"));

            System.Threading.Thread.Sleep(1000);
        }
    }
}