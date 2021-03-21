using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class ClsBase
    {
        protected WebDriverBase webDriverBase;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        [TestInitialize]
        public void CreateDriver()
        {
            webDriverBase = new WebDriverBase();
            webDriverBase.InstanceChrome("http://inventary.local/");
        }
      
        [TestCleanup]
        public void QuitDriver()
        {
            Thread.Sleep(3000);
            if (webDriverBase != null)
                webDriverBase.CloseBrowser();
        }
        private TestContext testContextInstance;

    }
}
