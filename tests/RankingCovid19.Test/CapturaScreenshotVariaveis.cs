using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace RankingCovid19.Test
{
    public class NomeDoProjeto
    {
        public IWebDriver driver;
        private string baseUrl;
        public string screenshotsPasta;
        int contador = 1;

        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseUrl = "https://www.google.com.br";
            screenshotsPasta = @"C:\Users\rodri\Desktop\Selenium\Evidencias\";
        }

        public void CapturaImagem()
        {
            Screenshot(driver, screenshotsPasta + "Imagem_" + contador++ + ".png");
            Thread.Sleep(500);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            driver.Navigate().GoToUrl(baseUrl + "/intl/pt-BR/about/");
            Thread.Sleep(1000);
            CapturaImagem();
            Thread.Sleep(1000);
        }
    }
}
