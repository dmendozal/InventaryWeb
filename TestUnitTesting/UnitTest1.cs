using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1;

namespace TestUnitTesting
{
    [TestClass]
    public class UnitTest1:ClsBase
    {
        [TestMethod]
        [TestCategory("Pruebas")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Configuration.csv", "Configuration#csv", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            string url = @"https://google.com";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            var ddd = driver.FindElement(By.CssSelector("input[class='gLFyf gsfi']"));
            ddd.Click();
            ddd.SendKeys("asdfas");
            driver.Close();
        }

        [TestMethod]
        [TestCategory("Pruebas")]
        public void TestMethod3()
        {
            WebDriverBase webDriverBase = new WebDriverBase();
            webDriverBase.InstanceChrome("http://inventary.local/");
            webDriverBase.SetText(By.CssSelector("input[class='gLFyf gsfi']"), "Hola");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.TextBox.Producto_Title), "Second with locator");
            webDriverBase.CloseBrowser();
        }


        /// <summary>
        /// Prueba de ABM Producto
        /// </summary>
        [TestMethod]
        [TestCategory("Producto")]
        public void WorkFlowProductUseCase()
        {
            string mainImage = "https://http2.mlstatic.com/sprite-x-225-lts-D_NQ_NP_725475-MLA31019302051_062019-F.jpg";
            string code = "PRD7"; //Codigo de producto 
            string name = "Sprite";
            string description = "Retornable. Sprite de 2 litros";
            int stock = 5;
            int salePrice = 12;
            int purchasePrice = 10;
            string expirationTime = "12/11/2019"; // MM/DD/YY
            string unit = "Litro";
            string UnitID = "UnitID";
            string category = "Bebidas";
            string CategoryID = "CategoryID";
            string provider = "Coca Cola";
            string ProviderID = "ProviderID";
            //BEGIN
            //STEP 1: Open browser in the url supermarket =  http://inventary.local/
            //STEP 2: Click in the header-button "Administracion"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Management_Header));
            //STEP 3: Click in the name "Productos"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Products_Action));
            //STEP 4: Click in "Crear nuevo producto"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Create));
            //STEP 5: fill inputs with the required data
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_Code),code);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_Name), name);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_Description), description);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_Stock), $"{stock}");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_PurchasePrice), $"{purchasePrice}");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_SalePrice), $"{salePrice}");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_MainImage), mainImage);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Product_ExpirationTime), expirationTime);
            webDriverBase.ClickOnSelect(unit,UnitID);
            webDriverBase.ClickOnSelect(category,CategoryID);
            webDriverBase.ClickOnSelect(provider,ProviderID);
            //STEP 6: Click in the button "Create"
            //STEP 7: Redirect To Main Page Producto
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Save));
            //STEP 8: Verify if the Product was inserted correctly 
            Assert.IsFalse(webDriverBase.VerifyProductIsVisible(name,description),"El producto no se guardo correctamente");


            //EDIT
            // SE REPITEN LOS 3 PRIMEROS PASOS
            //STEP 4: Click in "Editar" from select product 
            webDriverBase.ClickOnEdit(name, description);
            //altert the value
            description = "Esto es una prueba con selenium";
            //STEP 5: Modify the old value to new value
            webDriverBase.ModifyValuesOnSelector(description,Locator.GetTheBySelector(Locator.Product.Product_Description));
            //STEP 6: Click in the button "Save"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Save));
            //STEP 7: Redirect To Main Page
            Assert.IsTrue(webDriverBase.VerifyProductIsVisible(name, description), "El producto no se edito correctamente");

            //DELETE
            // SE REPITEN LOS 3 PRIMEROS PASOS
            //STEP 4: Click in "Eliminar" from select product
            webDriverBase.ClickOnDelete(name, description);
            //STEP 5: Click in "Delete" for confirm the proccess
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Delete));
            //STEP 6: Redirect to Main Page of Product
            //STEP 7: Verify if the product was deleted correctly
            Assert.IsTrue(webDriverBase.VerifyProductIsNotVisible(name, description), "El producto no se elimino correctamente");
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Generic.Back_To_Home));
        }

        [TestMethod]
        [TestCategory("Producto")]
        public void SearchProduct()
        {
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Management_Header));
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Products_Action));
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Product.Search_TextBox), "Sprite");
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Details));
        }

        [TestMethod]
        [TestCategory("Contacto")]
        public void SendMessageForUser()
        {
            string s = "message1";
            string name = "Jorge";
            string email = "Jorge@gmail.com";
            string message = $"{s}Esto es una prueba con selenium";
            //STEP 1: Open browser in the url supermarket =  http://inventary.local/
            //STEP 2: Click in the header-button "Contact"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Contact_Header));
            //STEP 3: Click in the icon with figure of "Message"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Contact.Message_Action));
            //STEP 4: fill inputs with the required data
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Contact.Name_Title), name);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Contact.Email_Title), email);
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Contact.Message_Title), message);
            //STEP 5: Click in the button "Enviar"
            //STEP 6: Redirect to Home Page
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Contact.Submit_Action));

            //CHECK IF THE MESSAGE WAS RECEIVED CORRECTLY
            //STEP 1: Open browser in the url supermarket =  http://inventary.local/
            //STEP 2: Click in the header-button "Administracion"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Management_Header));
            //STEP 3: Click en the name link "Bandeja de Entrada"
            //STEP 4: Redirect to new Page of all messages
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Contact_Action));
            //STEP 5: check if the message was received correctly
            Assert.IsTrue(webDriverBase.VerifyUserMessage(name, message));
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Generic.Redirect_Back));
        }
        [TestMethod]
        [TestCategory("Contacto")]
        public void ReceiveMessage()
        {
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Management_Header));
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Contact_Action));
            Assert.IsNotNull(webDriverBase.FindElement(Locator.GetTheBySelector(Locator.Contact.Verify_Message)));
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Generic.Redirect_Back));
        }

        [TestMethod]
        [TestCategory("Categoria")]
        public void WorkFlowCategoryUseCase()
        {
            string name = "Nueva Categoria";
            //BEGIN
            //STEP 1: Open browser in the url supermarket =  http://inventary.local/
            //STEP 2: Click in the header-button "Administracion"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Management_Header));
            //STEP 3: Click in the name "Productos"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Home.Products_Action));
            //STEP 4: Click in "Categoria" for view the category list 
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Category));
            //STEP 5: Click in "Crear nueva Categoria "
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Category.Category_Create));
            //STEP 6: fill inputs with the required data
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.Category.Category_Name), name);
            //STEP 7: Click in the button "Create"
            //STEP 8: Redirect To Main Page
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Category.Category_Save));
            //STEP 8: Verify if the Product was inserted correctly 
            Assert.IsTrue(webDriverBase.VerifyCategoryIsVisible(name), "La categoria no se guardo correctamente");
            
            //EDIT
            // SE REPITEN LOS 4 PRIMEROS PASOS
            //STEP 4: Click in "Editar" from select categoria
            webDriverBase.ClickOnEditCategory(name);
            //altert the value
            name = "Nueva categoria con selenium";
            ////STEP 5: Modify the old value to new value
            webDriverBase.ModifyValuesOnSelector(name, Locator.GetTheBySelector(Locator.Category.Category_Name));
            ////STEP 6: Click in the button "Save"
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Category.Category_Save));
            ////STEP 7: Redirect To Main Page
            Assert.IsTrue(webDriverBase.VerifyCategoryIsVisible(name), "La categoria no se edito correctamente");



            //DELETE
            // SE REPITEN LOS 4 PRIMEROS PASOS
            //STEP 4: Click in "Eliminar" from select product
            webDriverBase.ClickOnDeleteCategory(name);
            //STEP 5: Click in "Delete" for confirm the proccess
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Product.Product_Delete));
            //STEP 6: Redirect to Main Page of Product
            //STEP 7: Verify if the Category was deleted correctly
            Assert.IsTrue(webDriverBase.VerifyCategoryIsNotVisible(name), "La categoria no se elimino correctamente");
            webDriverBase.Click(Locator.GetTheBySelector(Locator.Generic.Back_To_Home));
        }
    }
}