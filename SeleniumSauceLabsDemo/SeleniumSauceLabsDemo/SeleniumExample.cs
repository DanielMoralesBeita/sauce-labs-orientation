using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumSauceLabsDemo
{
    [TestFixture(Browser.Chrome, "Windows 8.1")]
    [TestFixture(Browser.Firefox, "Linux")]
    [TestFixture(Browser.InternetExplorer, "Windows 7")]
    [TestFixture(Browser.MicrosoftEdge, "Windows 10")]
    [TestFixture(Browser.Safari, "macOS 10.13")]
    public class SeleniumExample
    {
        private readonly IWebDriverAdapter _webDriverAdapter;

        public SeleniumExample(Browser browser, string operatingSystem)
        {
            _webDriverAdapter = new WebDriverAdapter(Session.Remote, browser, operatingSystem);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriverAdapter.Quit();
        }

        [TestCase("someUserName", "somePassword", "Some User Name")]
        public void LoginToHyundai(string userName, string passWord, string fullUserName)
        {
            const string autoAppHyundaiUrl = "https://d-hyundai-sales.salesnext.com/login";

            _webDriverAdapter.Navigate(autoAppHyundaiUrl);
            _webDriverAdapter.SendText(By.CssSelector("#input-1"), userName);
            _webDriverAdapter.SendText(By.CssSelector("#input-2"), passWord);
            _webDriverAdapter.Click(By.CssSelector("#form > div.submit-container.style-scope.ci-page-login > paper-button > span"));

            var webElement = _webDriverAdapter.FindElement(By.CssSelector("#profileCard > p"));
            var result = webElement.Text;

            Assert.That(fullUserName, Is.EqualTo(result));
        }
    }
}