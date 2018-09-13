using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;

namespace SeleniumSauceLabsDemo
{
    public enum Session
    {
        Local,
        Remote
    }

    public enum Browser
    {
        Chrome,
        Firefox,
        InternetExplorer,
        MicrosoftEdge,
        Safari
    }

    public interface IWebDriverAdapter : IDisposable
    {
        void Navigate(string url);
        void SendText(By by, string keysToSend);
        void Click(By by);
        void Quit();
        IWebElement FindElement(By by);
    }

    public class WebDriverAdapter : IWebDriverAdapter
    {
        private IWebDriver _webDriver;
        private INavigation _navigation;
        private readonly Session _session;
        private readonly Browser _browser;
        private readonly string _operatingSystem;
        private readonly string _browserVersion;

        public WebDriverAdapter(Session session, Browser browser, string operatingSystem, string browserVersion = "latest")
        {
            _session = session;
            _browser = browser;
            _operatingSystem = operatingSystem;
            _browserVersion = browserVersion;
        }

        public void Navigate(string url)
        {
            if (_webDriver == null)
            {
                InstantiateWebDriver();
            }

            _navigation.GoToUrl(url);
        }

        public void SendText(By by, string keysToSend)
        {
            if (_webDriver == null)
            {
                InstantiateWebDriver();
            }

            var webElement = _webDriver.FindElement(by);

            webElement.SendKeys(keysToSend);
        }

        public void Click(By by)
        {
            if (_webDriver == null)
            {
                InstantiateWebDriver();
            }

            var webElement = _webDriver.FindElement(by);

            webElement.Click();
        }

        public void Quit()
        {
            try
            {
                var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                var javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
                var script = string.Concat("sauce:job-result=", passed ? "passed" : "failed");

                javaScriptExecutor?.ExecuteScript(script);
            }
            finally
            {
                _webDriver.Quit();
                _webDriver.Dispose();
            }
        }

        public IWebElement FindElement(By by)
        {
            var webElement = _webDriver.FindElement(by);

            return webElement;
        }

        private void InstantiateWebDriver()
        {
            const string sauceLabsUriString = "http://ondemand.saucelabs.com:80/wd/hub";

            var driverOptions = CreateDriverOptions(_browser, _operatingSystem, _browserVersion);
            var webWebDriver = new RemoteWebDriver(new Uri(sauceLabsUriString), driverOptions.ToCapabilities());

            _navigation = webWebDriver.Navigate();

            var options = webWebDriver.Manage();

            if (_session == Session.Local)
            {
                options.Window.Maximize();
            }

            var timeouts = options.Timeouts();
            var timeSpan = TimeSpan.FromSeconds(30);

            timeouts.PageLoad = timeSpan;
            timeouts.AsynchronousJavaScript = timeSpan;
            timeouts.ImplicitWait = timeSpan;

            _webDriver = webWebDriver;
        }

        private DriverOptions CreateDriverOptions(Browser browser, string operatingSystem, string browserVersion)
        {
            dynamic driverOptions;

            switch (browser)
            {
                case Browser.Chrome:
                    driverOptions = new ChromeOptions();
                    break;

                case Browser.Firefox:
                    driverOptions = new FirefoxOptions();
                    break;

                case Browser.InternetExplorer:
                    driverOptions = new InternetExplorerOptions();
                    break;

                case Browser.MicrosoftEdge:
                    driverOptions = new EdgeOptions();
                    break;

                case Browser.Safari:
                    driverOptions = new SafariOptions();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            var testName = $"[{TestContext.CurrentContext.Test.MethodName}].[{operatingSystem}].[{browser}].[{browserVersion}]";

            switch (browser)
            {
                case Browser.Chrome:
                case Browser.Firefox:
                case Browser.InternetExplorer:
                    driverOptions.AddAdditionalCapability("username", sauceUserName, true);
                    driverOptions.AddAdditionalCapability("accessKey", sauceAccessKey, true);
                    driverOptions.AddAdditionalCapability("name", testName, true);
                    driverOptions.AddAdditionalCapability("platform", operatingSystem, true);
                    driverOptions.AddAdditionalCapability("version", browserVersion, true);

                    break;

                case Browser.MicrosoftEdge:
                case Browser.Safari:
                    driverOptions.AddAdditionalCapability("username", sauceUserName);
                    driverOptions.AddAdditionalCapability("accessKey", sauceAccessKey);
                    driverOptions.AddAdditionalCapability("name", testName);
                    driverOptions.AddAdditionalCapability("platform", operatingSystem);
                    driverOptions.AddAdditionalCapability("version", browserVersion);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            return driverOptions;
        }

        public void Dispose()
        {
            Quit();
        }
    }
}