using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RankingCovid19.Domain.Entities;
using System;
using System.Linq;

namespace RankingCovid19.Webscraping
{
    public class SummaryPage
    {
        private SeleniumConfigurations _configurations;
        private IWebDriver _driver;

        public SummaryPage(SeleniumConfigurations configurations)
        {
            _configurations = configurations;

            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            _driver = new FirefoxDriver(options);
        }

        public void LoadPage(string country)
        {
            _driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(_configurations.Timeout);
            _driver.Navigate().GoToUrl(
                $"{_configurations.Url}/{country}");
        }

        internal void Close()
        {
            _driver.Quit();
            _driver = null;
        }

        public Covid19Summary GetSummary(string country)
        {
            LoadPage(country);

            var totals = _driver
                .FindElement(By.ClassName("overview"))
                .FindElement(By.ClassName("overviewContent"))
                .FindElement(By.ClassName("infoTile"))
                .FindElement(By.ClassName("infoTileData"))
                .FindElements(By.ClassName("total")).Select(s => s.Text).ToList();

            var position = _driver
                .FindElement(By.ClassName("combinedArea"))
                .FindElement(By.ClassName("areas"))
                .FindElements(By.ClassName("areaDiv"))
                .Select(t => t.FindElement(By.ClassName("area"))
                .FindElement(By.ClassName("areaName")).Text).ToList();

            var activeCases = long.Parse(totals[0].Substring(0, totals[0].IndexOf("\r")).Replace(".", ""));
            var recoveredCases = long.Parse(totals[1].Substring(0, totals[1].IndexOf("\r")).Replace(".", ""));
            var fatalCases = long.Parse(totals[2].Substring(0, totals[2].IndexOf("\r")).Replace(".",""));

            var covid19Summary = new Covid19Summary(country, activeCases, recoveredCases, fatalCases);

            return covid19Summary;
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
