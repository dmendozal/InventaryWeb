using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    public class WebDriverBase
    {
        private IWebDriver _driver;

        /// <summary>
        /// Create Instace of browser chrome.
        /// </summary>
        /// <param name="url"></param>
        public void InstanceChrome(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            _driver = driver;
        }

        public void ModifyValuesOnSelector(string description,By selector)
        {
            _driver.FindElement(selector).Clear();
            SetText(selector, description);
        }
        /// <summary>
        /// Click in the button Edit of category page
        /// </summary>
        /// <param name="name"></param>
        public void ClickOnEditCategory(string name)
        {
            string xpath = $"//td[contains(text(),'{name}')]//parent::tr//a[contains(text(),'Editar')]";
            Click(By.XPath(xpath));
        }
        /// <summary>
        /// Click in the button Edit of category page
        /// </summary>
        /// <param name="name"></param>
        public void ClickOnDeleteCategory(string name)
        {
            string xpath = $"//td[contains(text(),'{name}')]//parent::tr//a[contains(text(),'Delete')]";
            Click(By.XPath(xpath));
        }

        /// <summary>
        /// Click in the button Editar and redirect to new page
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void ClickOnEdit(string name, string description)
        {
            string xpath = $"//*[contains(text(),'{name}')]//parent::tr//td[contains(text(),'{description}')]//parent::tr//td//a[contains(text(),'Editar')]";
            Click(By.XPath(xpath));
        }
        /// <summary>
        /// Click in the button Editar and redirect to new page
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void ClickOnDelete(string name, string description)
        {
            string xpath = $"//*[contains(text(),'{name}')]//parent::tr//td[contains(text(),'{description}')]//parent::tr//td//a[contains(text(),'Eliminar')]";
            Click(By.XPath(xpath));
        }
        /// <summary>
        /// select a item of a tag select
        /// </summary>
        /// <param name="data"></param>
        /// <param name="selectID"></param>
        public void ClickOnSelect(string data, string selectID)
        {
            try
            {
                string xpath = $"//select//option[text()='{data}']";
                _driver.FindElement(By.Id(selectID)).Click();
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                _driver.FindElement(By.XPath(xpath)).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
                throw;
            }
            //ClickToElement(By.Id(selectID));
            //ClickToElement(By.XPath(xpath));
        }

        public IWebElement FindElement(By selector)
        {
            return _driver.FindElement(selector);
        }

        /// <summary>
        /// Click on a element XPATH or CSS_selector
        /// </summary>
        /// <param name="selector"></param>

        public void Click(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
                wait.Until(ExpectedConditions.ElementToBeClickable(selector));
                Thread.Sleep(2000);
                ClickToElement(selector);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR ASSERT IS NULL");
            }
        }
        /// <summary>
        /// Verify if a category is not visible
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VerifyCategoryIsNotVisible(string name)
        {
            try
            {
                string xpath = $"//*[contains(text(),'{name}')]";
                return IsNotVisible(By.XPath(xpath), 10);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Verify if a category was inserted correctly
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VerifyCategoryIsVisible(string name)
        {
            try
            {
                string xpath = $"//*[contains(text(),'{name}')]";
                MoveToElement(By.XPath(xpath));
                return IsVisible(By.XPath(xpath), 20);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Verify if a product was inserted correctly
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool VerifyProductIsVisible(string name,string description)
        {
            try
            {
                string xpath = $"//*[contains(text(),'{name}')]//parent::tr//td[contains(text(),'{description}')]";
                MoveToElement(By.XPath(xpath));
                return IsVisible(By.XPath(xpath),20);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Verify if the product not is visible in the DOM
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool VerifyProductIsNotVisible(string name, string description)
        {
            try
            {
                string xpath = $"//*[contains(text(),'{name}')]//parent::tr//td[contains(text(),'{description}')]";
                return IsNotVisible(By.XPath(xpath), 10);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify the workflow contact
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool VerifyUserMessage(string user,string message)
        {
            try
            {
                string xpath = $"//*[contains(text(),'{user}')]//parent::tr//td[contains(text(),'{message}')]";
                MoveToElement(By.XPath(xpath));
                return IsVisible(By.XPath(xpath), 20); ;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Set Text to control
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="texto"></param>
        public void SetText(By selector,string texto)
        {
            try
            {
                MoveToElement(selector);
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
                Assert.IsNotNull(wait.Until(ExpectedConditions.ElementIsVisible(selector)));
                Thread.Sleep(2000);
                var dd = _driver.FindElement(selector);
                dd.SendKeys(texto);
            }
            catch (Exception)
            {
                
                Console.WriteLine("ERROR ASSERT IS NULL");
            }
        }
        /// <summary>
        /// Verify if the element is clickeable in the DOM with a time determinated
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool IsClikable(By selector, int time = 0)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.ElementToBeClickable(selector)) != null ? true : false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Verify if the element is visible in the DOM with a time determinated
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool IsVisible(By selector, int time = 0)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.ElementIsVisible(selector)) != null ? true : false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsNotVisible(By selector, int time = 0)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(selector));
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Close Browser.
        /// </summary>
        public void CloseBrowser()
        {
            _driver.Close();
        }
        /// <summary>
        /// Move the screen with scroll in the selector 
        /// </summary>
        /// <param name="selector"></param>
        private void MoveToElement(By selector)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
            je.ExecuteScript("arguments[0].scrollIntoView(false);", _driver.FindElement(selector));
        }
        /// <summary>
        /// Click in the selector 
        /// </summary>
        /// <param name="selector"></param>
        private void ClickToElement(By selector)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
            je.ExecuteScript("arguments[0].click();", _driver.FindElement(selector));
        }

    }
}
