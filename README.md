# Sauce Labs Demonstration

* [What is Sauce Labs?](##what-is-Sauce-Labs "What is Sauce Labs?")
* [Which problems does it solve for us?](##Which-problems-does-it-solve-for-us "Which problems does it solve for us?")
* [How will it help us?](##How-will-it-help-us "How will it help us?")
* [What features does it offer?](##What-features-does-it-offer "What features does it offer?")
* [When should you run tests with it?](##When-should-you-run-tests-with-it "When should you run tests with it?")
* [How do you run tests with it?](##How-do-you-run-tests-with-it "How do you run tests with it?")
* [Example Sauce Lab Projects](##Example-Sauce-Labs-Projects "Example Sauce Labs Projects") - Sauce Labs with Polymer and Selenium code examples!
* [Sauce Labs Resources](##Sauce-Labs-Resources "Sauce Labs Resources")

---
## What is Sauce Labs?
Sauce Labs is a continuous cloud testing platform for web and mobile applications.  It provides the ability to run tests against multiple operating systems, platforms, devices, and browsers in parallel.

##### [back to top](#sauce-labs-demonstration "Home")
---

## Which problems does it solve for us?
* Challenges running all of our tests on all platforms, browsers, and devices.
* Manual time-consuming regression testing against a limited set of options.
* Expensive trivial bug tickets that are introduced and come back from QA.
* Unknown, hidden, and intermittent bugs introduced by new changes or other bug fixes.

##### [back to top](#sauce-labs-demonstration "Home")
---

## How will it help us?
* Finds bugs faster before they reach QA.
* Delivers apps faster.
* Improves quality.
* Improve efficiency.
* Provides comprehensive coverage.
* Provides enterprise security and scalability.
* Offers cross-browser testing on all platforms.
* Accelerates release cycles.
* Fewer bugs reported in production, leading to loyal users.
* Saves testing time through parallelization over multiple platforms, browsers, and device combinations.
* Helps eliminate manual regression testing before submitting pull requests.
* Provides QA with more time for performance, load, and stress testing.

##### [back to top](#sauce-labs-demonstration "Home")
---

## What features does it offer?

* Over 800 OS and browser combinations.
* Over 200 emulators and simulators.
* Over 2000-real devices for public and private testing.
* Spins up a new "single-use" virtual machine for every test.
* Configurable screenshot functionality.
* Configurable video playback functionality.
* [Platform Configurator](https://wiki.saucelabs.com/display/DOCS/Platform+Configurator "Platform Configurator") - High Level Configuration Overview

##### [back to top](#sauce-labs-demonstration "Home")
---

## When should you run tests with it?

* During active test-driven development tests are ran locally to preserve time and Sauce Labs usage.
* Newly written tests individually should point at Sauce Labs to be ran by the developer ideally just before submitting it for code review.
* CI/CD architecture should reasonably run all tests through Sauce Labs against and integration branch before it reaches QA.
* Whenever, but keep Sauce Labs usage in mind.

##### [back to top](#sauce-labs-demonstration "Home")
---

## How do you run tests with it?

The four most common ways to run tests via Sauce Labs.

1. [Command Line](###Running-tests-via-Command-Line "Command Line")
2. [Web Browser](###Running-tests-via-Web-Browser "Web Browser")
3. [Selenium Test Library](###Running-tests-via-Selenium-Test-Library "Selenium Test Library")
4. [Virtual Machine](###Debugging-and-troubleshooting-via-Sauce-Labs-Virtual-Machine "Virtual Machine") - Debugging and Troubleshooting

##### [back to top](#sauce-labs-demonstration "Home")
---

### Running tests via Command Line

1. Please refer to the following repository [polymer-sauce-labs-demo](##Example-Sauce-Labs-Projects "Example Sauce Labs Projects") for download and experimentation.
2. Complete required [local environment setup](##Required-Local-Environment-Setup "Local Environment Setup") steps.
3. Run `npm install -g web-component-tester`
4. Run `bower install --save-dev web-component-tester`
5. Save the following web component test json configuration file contents in the root directory of the web project.
    * Name it whatever you like so long as you call it as such from the command line.
    * [Minimum Example](###Minimum-web-component-test-configuration-file-example)
    * [Maximum Example](###Maximum-web-component-test-configuration-file-example)
6. Run any of the following commands.

| Command                                                                                                           | Description                                                      |
|-------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------|
| `wct --expanded --configFile .\wct.config.json`                                                                   | Runs all tests.                                                  |
| `wct --expanded --configFile .\wct.config.json .\test\polymer-sauce-labs-demo_test.html`                          | Runs specified test class.                                       |
| `wct --expanded --configFile .\wct.config.json --job-name 'My Job Name'`                                          | Runs all tests with specified job name.                          |
| `wct --expanded --configFile .\wct.config.json --job-name 'My Job Name' .\test\polymer-sauce-labs-demo_test.html` | Runs specified test class with specified job name.               |
| `wct --help`                                                                                                      | Web component tester help menu commands.                         |
| `polymer test`                                                                                                    | Polymer web component tester command (**see CLI notes**)         |
| `polymer --help`                                                                                                  | Polymer test help menu commands.                                 |

---
CLI Notes
  * Sauce Labs tests are ran remotely when `"sauce"` section of [wct.config.json](###Minimum-web-component-test-configuration-file-example) is enabled `true`.
  * `--expanded` prints a friendly one-liner status of the test(s).
  * User credentials are unnecessary as command line arguments when credentials environment variables are set (best practice).
  * Use `--help` for additional arguments and usages.
---

##### [back to How do you run tests with it?](##How-do-you-run-tests-with-it?)

## Required Local Environment Setup

1. Set the following key value pairs as **System** environment variables for your desired installed browsers.
2. **Critical note for Windows users**:  Make sure all the following values are entered then moved to the top of environment variable path list. Windows will traverse through all environment variables when searching for appropriate key value pair matches.  This has been known to take three to five minutes to begin test runs if the environment variables are not immediately found at the top of the environment variable path list. Environment variables can be repositioned when entered as a **Path** environment variable.  This is only necessary when running tests locally via command line when Sauce Labs is disabled.

3. For Windows machine users, see [How to set Windows environment variables](###How-to-set-Windows-environment-variables).



    | Key                                          | Value                                                         |
    |----------------------------------------------|---------------------------------------------------------------|
    | `SAUCE_USERNAME`                             | _mySauceLabsUserName_                                         |
    | `SAUCE_ACCESS_KEY`                           | _00000000-0000-0000-0000-000000000000_                        |
    | `LAUNCHPAD_BROWSERS`                         | _chrome, firefox, ie, opera_                                  |
    | `LAUNCHPAD_CHROME`                           | _C:\Program Files\Google\Chrome\Application\chrome.exe_       |
    | `LAUNCHPAD_FIREFOX`                          | _C:\Program Files\Mozilla Firefox\firefox.exe_                |
    | `LAUNCHPAD_IE`                               | _C:\Windows\explorer.exe_                                     |
    | `LAUNCHPAD_OPERA`                            | _C:\Program Files\Opera\00.0.0000.00\opera.exe_               |

4. For Mac OS/Linux machine users:
    * Please refer to [Sauce Labs Authentication Credentials](https://wiki.saucelabs.com/display/DOCS/Best+Practice%3A+Use+Environment+Variables+for+Authentication+Credentials)
    * Sauce Labs Authentication Credentials are mentioned in the resources section [Setting Environment Variables](##Sauce-Labs-Resources).

##### [back to Running tests via Command Line](###Running-tests-via-Command-Line)
---

### How to set Windows environment variables

1. Click **Start** on the task bar.
2. For **Search programs and fields**, enter Environment Variables.
3. Click **Edit the environment variables**.  This will open the **System Properties** dialog.
4. Click **Environment Variables**.  This will open the **Environment Variables** dialog.
5. In the **System variables** section, click **New**.
6. This will open the **New System Variable** dialog.
7. For **Variable name**, enter `SAUCE_USERNAME`.
8. For **Variable value**, enter your Sauce username `mySauceLabsUserName`.
9. Click OK.
10. Repeat 4 - 8 to set up the `SAUCE_ACCESS_KEY`.
11. Sauce access key is the GUID value.

##### [back to Required Local Environment Setup](##Required-Local-Environment-Setup)

---

### Minimum web component test configuration file example
```js
{
  "plugins": {
    "local": {
      "browsers": [
        "chrome"
      ],
      "browserOptions": {
        "chrome": [
          "headless",
          "disable-gpu",
          "no-sandbox"
        ]
      }
    }
  }
}
```
##### [back to Running tests via Command Line](###Running-tests-via-Command-Line)
---

### Maximum web component test configuration file example
```js
{
  "plugins": {
    "local": {
      "browsers": [
        "chrome",
        "firefox"
      ],
      "browserOptions": {
        "chrome": [
          "headless",
          "disable-gpu",
          "no-sandbox"
        ],
        "firefox": [
          "-headless",
        ]
      }
    },
    "sauce": {
      "disabled": true,
      "browsers": [
        {
          "browserName": "internet explorer",
          "platform": "Windows 8.1",
          "version": "11"
        },
        {
          "browserName": "safari",
          "platform": "OS X 10.11",
          "version": "9"
        }
      ]
    }
  }
}
```
##### [back to Running tests via Command Line](###Running-tests-via-Command-Line)
---

### Running tests via Web Browser

1. Run `npm install -g web-component-tester`
2. Run `bower install --save-dev web-component-tester`
3. In the root folder of your web project **\test\\** folder or directly in your **test.html** file, modify your `index.html` file with the following html code.
```html
<script>
  WCT.loadSuites([
    'polymer-sauce-labs-demo_test.html'
  ]);
</script>
```
For Polymer polyfill information, please see [Test with polyfills](https://www.polymer-project.org/3.0/docs/tools/tests) for more details
```html
<script>
  WCT.loadSuites([
    'polymer-sauce-labs-demo_test.html?dom=shadow',
    'polymer-sauce-labs-demo_test.html?wc-shadydom=true&wc-ce=true'
  ]);
</script>
```
4. Run `polymer serve`
5. Paste the following line in your desired browser to test.
    * `localhost:8080/polymer-sauce-labs-demo/test/polymer-sauce-labs-demo_test.html`
    * The sample above runs basic-test.html twice, once using native APIs (where the browser supports them), and once using using all of the polyfills.

##### [back to How do you run tests with it?](##How-do-you-run-tests-with-it?)
---

### Running tests via Selenium Test Library
* **CSharp NUnit Selenium Example**: Class Constructor Initialization.
* Please refer to the following repository [SeleniumSauceLabsDemo](##Example-Sauce-Labs-Projects "Example Sauce Labs Projects") for download and experimentation.
* See NETCore SeleniumSauceLabsDemo for details.
* See [Example Selenium Scripts for Automated Website Tests](https://wiki.saucelabs.com/display/DOCS/Example+Selenium+Scripts+for+Automated+Website+Tests) for setting up test classes with other languages.

```cs
public class SeleniumExample
{
    private readonly IWebDriver _webDriver;

    public SeleniumExample()
    {
      const string sauceLabsUriString = "http://ondemand.saucelabs.com:80/wd/hub";

      var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
      var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
      var safariOptions = new SafariOptions();

      safariOptions.AddAdditionalCapability("username", sauceUserName);
      safariOptions.AddAdditionalCapability("accessKey", sauceAccessKey);
      safariOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
      safariOptions.AddAdditionalCapability("platform", "macOS 10.13");
      safariOptions.AddAdditionalCapability("version", "latest");

      _webDriver = new RemoteWebDriver(new Uri(sauceLabsUriString), safariOptions.ToCapabilities());
    }
}
```
##### [back to How do you run tests with it?](##How-do-you-run-tests-with-it?)
---

### Debugging and troubleshooting via Sauce Labs Virtual-Machine
1. Navigate to url [Sauce Connect Proxy Setup](https://wiki.saucelabs.com/display/DOCS/Sauce+Connect+Proxy)
2. Download the appropriate proxy executable.
3. Adjust the configuration file accordingly.
4. Run your local server url remote via Sauce Labs.
##### [back to How do you run tests with it?](##How-do-you-run-tests-with-it?)
---

## Example Sauce Labs Projects
* Projects are located in this repository.
  * **Polymer Sauce Labs Project** `.\polymer-sauce-labs-demo`
  * **Selenium Sauce Labs Project** `.\SauceLabsDemo`
* Polymer project requires `npm`, `bower`, and `web-component-tester` installed.
  * See the following repository for Polymer environmental setup [mtz-app-knowledge-center](https://github.com/MaritzSTL/mtz-app-knowledge-center "mtz-app-knowledge-center") - Application containing detailed introductions to various concepts for dev on-boarding.
* Selenium project prerequisites
  * [Visual Studio Community 2017](https://visualstudio.microsoft.com/downloads "Windows Primary Users") - Windows Primary Users
  * [VS Code](https://code.visualstudio.com/download "Mac, Windows, and Linux Users") - Mac, Windows, and Linux Users
  * Modify the actual `userName`, `password`, yourAppUrl accordingly.
  * Selenium code examples are not asynchronous, but the `NUnit` test library used in this example can be configured to call each configuration asynchronously.
  * Overall, regardless of the language used to call Sauce Labs, the test execution or test manager configured should call each test or suite asynchronously.
  * Based on my initial research, Sauce Labs will create a new single use virtual machine for each test or suite of tests, but the test runner must send Sauce Labs these tests an isolated asynchronous manner.
  * To run tests locally, local drivers for each browser will need to be called locally on the tester's machine (please refer to the `.\Drivers` folder for this repository).
  * Please full project for complete working implementation.

    ```cs
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
            const string autoAppHyundaiUrl = "https://yourAppUrl/login";

            _webDriverAdapter.Navigate(autoAppHyundaiUrl);
            _webDriverAdapter.SendText(By.CssSelector("#input-1"), userName);
            _webDriverAdapter.SendText(By.CssSelector("#input-2"), passWord);
            _webDriverAdapter.Click(By.CssSelector("#form > div.submit-container.style-scope.ci-page-login > paper-button > span"));

            var webElement = _webDriverAdapter.FindElement(By.CssSelector("#profileCard > p"));
            var result = webElement.Text;

            Assert.That(fullUserName, Is.EqualTo(result));
        }
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

        driverOptions.AddAdditionalCapability("username", sauceUserName);
        driverOptions.AddAdditionalCapability("accessKey", sauceAccessKey);
        driverOptions.AddAdditionalCapability("name", testName);
        driverOptions.AddAdditionalCapability("platform", operatingSystem);
        driverOptions.AddAdditionalCapability("version", browserVersion);

        return driverOptions;
    }
    ```

##### [back to top](#sauce-labs-demonstration "Home")
---

## Sauce Labs Resources

* Documentation
  * [Home](https://saucelabs.com "Home") - Home Login
  * [Documentation Wiki](https://wiki.saucelabs.com "Documentation Wiki") - The Sauce Labs Cookbook Home
  * [Sauce Labs eBook](http://info.saucelabs.com/FY18Q2-AST-Continuous-Testing-eBook_LP.html "Sauce Labs eBook") - The Essential Guide to Continuous Testing
  * [Overview of Sauce Labs](https://www.youtube.com/watch?v=Pqu4tY5XbIs&feature=youtu.be "Overview of Sauce Labs") - Sauce Labs Video Overview
  * [View Dashboard](https://saucelabs.com/beta/dashboard "View Dashboard") - Dashboard for Automated Builds, Automated Tests, and Live Tests
  * [View Automated Tests](https://saucelabs.com/beta/dashboard/tests "View Automated Tests") - View Automated Tests Via Sauce Labs
  * [View Active Tunnels](https://saucelabs.com/beta/tunnels "View Active Tunnels") - View Active Tunnels
* Supported Platforms
  * [Platforms](https://saucelabs.com/platforms "Platforms") - Desktops, Simulators, Emulators, and Real Devices
  * [Devices](https://saucelabs.com/devices "Devices") - Devices
* Configuration
  * [Platform Configurator](https://wiki.saucelabs.com/display/DOCS/Platform+Configurator "Platform Configurator") - Platform Configuration Generator
  * [Environment Variables Options](https://wiki.saucelabs.com/display/DOCS/Environment+Variables+Used+by+Sauce+Connect "Environment Variable Options") - Environment Variable Options
  * [Setting Environment Variables](https://wiki.saucelabs.com/display/DOCS/Best+Practice%3A+Use+Environment+Variables+for+Authentication+Credentials "Setting Environment Variables") - Setting Environment Variables
* Sauce Connect Proxy
  * [Virtual Machine Setup](https://wiki.saucelabs.com/display/DOCS/Sauce+Connect+Proxy "Virtual Machine Setup") - Debugging and Troubleshooting
* Leading Practices
    * [Avoid Recording](https://youtu.be/hqAOP-m-eZI?t=10 "Avoid Recording") - Selenium Tests Should Be Autonomously Ran in Parallel
    * [Avoid Using XPath](https://youtu.be/gw6dtdB0w3o?t=10 "Avoid Using XPath") - Use CSS Selectors Over Using XPath
    * [Avoid Using Sleep](https://youtu.be/SCG-U8hhRFI?t=10 "Avoid Using Sleep") - Use Explicit or Implicit Waits in Your Tests
    * [Avoid Multiple Test Cases In Single Session](https://youtu.be/Ulzle1QUyCY?t=10 "Avoid Multiple Test Cases In Single Session") - Write Smaller Atomic Tests
* Command Line References
  * [Sauce Connect Command Line Reference](https://wiki.saucelabs.com/display/DOCS/Sauce+Connect+Command+Line+Reference "Sauce Connect Command Line Reference") - Sauce Labs Command Line Arguments
* Sauce Labs Selenium Resources
  * [Sauce Labs Required Selenium Configuration](https://wiki.saucelabs.com/display/DOCS/Test+Configuration+Options#TestConfigurationOptions-RequiredSeleniumTestConfigurationSettings "Sauce Labs Required Selenium Configuration")
  * [Example Selenium Scripts for Automated Website Tests](https://wiki.saucelabs.com/display/DOCS/Example+Selenium+Scripts+for+Automated+Website+Tests "Example Selenium Scripts for Automated Website Tests") - Example Test Fixtures for Other Languages
  * [Selenium Lunch & Learn Recording](https://zoom.us/recording/play/BzXcrdC_2eNyxDW7shrgtwbRg_iBiV3ofzLBW072tLGoknEQsq00TC50C2h9iInO?startTime=1535648320000 "Selenium Essential Training") - Selenium Essential Training
* Sauce Labs Polymer Resources
  * [Polymer Testing Reference](https://www.polymer-project.org/3.0/docs/tools/tests "Polymer Testing Reference") - Polymer Testing
  * [Polymer Tools Reference](https://github.com/Polymer/tools/tree/master/packages/web-component-tester "Polymer Web Component Testing") - Polymer Web Component Testing
  * [Maritz Polymer Knowledge Center](https://github.com/MaritzSTL/mtz-app-knowledge-center "Maritz Polymer Knowledge Center") - Polymer Knowledge Center

##### [back to top](#sauce-labs-demonstration "Home")