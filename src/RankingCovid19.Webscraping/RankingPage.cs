using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.ValueTypes;
using RankingCovid19.Webscraping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RankingCovid19.Webscraping
{
    public class RankingPage
    {
        private SeleniumConfigurations _configurations;
        private IWebDriver _driver;

        public RankingPage(SeleniumConfigurations configurations)
        {
            _configurations = configurations;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            _driver = new FirefoxDriver(options);
        }

        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(_configurations.Timeout);
            _driver.Navigate().GoToUrl(
                $"{_configurations.Url}");
        }

        internal void Close()
        {
            _driver.Quit();
            _driver = null;
        }

        public List<CountryInputDto> LoadRanking()
        {
            var rankings = new List<CountryInputDto>();

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[name()='svg']/*[name()='rect']"))).Click().Perform();

            var countries = _driver.FindElements(By.XPath("//div[contains(@class, 'areaName')]")).Select(c => c.Text).ToList();
            countries.Remove("Global");
            
            foreach (var country in countries)
            {
                new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[name()='svg']/*[name()='rect']"))).Click().Perform();

                new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath($"//div[contains(@id,'{country.ToLower().Replace(" ", "")}')]"))).Click().Perform();

                var totals = _driver
                    .FindElement(By.ClassName("overview"))
                    .FindElement(By.ClassName("overviewContent"))
                    .FindElement(By.ClassName("infoTile"))
                    .FindElement(By.ClassName("infoTileData"))
                    .FindElements(By.ClassName("total")).Select(t => t.Text).ToList();

                List<long> totalsValues = new List<long>();
                foreach (string v in totals)
                {
                    if (v.IndexOf("\r") > 0)
                        totalsValues.Add(long.Parse(v.Substring(0, v.IndexOf("\r")).Replace(".", "")));
                    else
                    {
                        if (long.TryParse(v, out long result))
                            totalsValues.Add(result);
                        else
                            totalsValues.Add(long.MinValue);
                    }

                }

                var activeCases = totalsValues[0];
                var recoveredCases = totalsValues[1];
                var fatalCases = totalsValues[2];

                rankings.Add(new CountryInputDto
                {
                    Name = country,
                    Summary = new Covid19RankingDto(new Covid19Ranking(activeCases, recoveredCases,
                                                fatalCases, countries.IndexOf(country) + 1))
                });
            }
            return rankings;
        }
    }
}
