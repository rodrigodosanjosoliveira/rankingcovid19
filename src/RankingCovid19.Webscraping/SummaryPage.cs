﻿using OpenQA.Selenium;
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

            _driver = new FirefoxDriver(
                _configurations.DriverPath,
                options);
        }

        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(_configurations.Timeout);
            _driver.Navigate().GoToUrl(
                _configurations.Url);
        }

        internal void Close()
        {
            _driver.Quit();
            _driver = null;
        }

        public Covid19Summary GetSummary()
        {
            Covid19Summary summary = new Covid19Summary();

            string activeCases = _driver
                .FindElement(By.ClassName("infoTileData"))
                .FindElement(By.ClassName("description"))
                .FindElement(By.ClassName("total"))
                .Text.Split(new char[] { ' ' }).Last();

            //var dadosConferencias = _driver
            //    .FindElements(By.ClassName("responsive-table-wrap"));
            //var captions = _driver
            //    .FindElements(By.ClassName("table-caption"));

            //for (int i = 0; i < captions.Count; i++)
            //{
            //    var caption = captions[i];
            //    Conferencia conferencia = new Conferencia();
            //    conferencia.Temporada = temporada;
            //    conferencia.DataCarga = dataCarga;
            //    conferencia.Nome =
            //        caption.FindElement(By.ClassName("long-caption")).Text;
            //    conferencias.Add(conferencia);

            //    int posicao = 0;
            //    var conf = dadosConferencias[i];
            //    var dadosEquipes = conf.FindElement(By.TagName("tbody"))
            //        .FindElements(By.TagName("tr"));
            //    foreach (var dadosEquipe in dadosEquipes)
            //    {
            //        var estatisticasEquipe =
            //            dadosEquipe.FindElements(By.TagName("td"));

            //        posicao++;
            //        Equipe equipe = new Equipe();
            //        equipe.Posicao = posicao;
            //        equipe.Nome =
            //            estatisticasEquipe[0].FindElement(
            //                By.ClassName("team-names")).GetAttribute("innerHTML");
            //        equipe.Vitorias = Convert.ToInt32(
            //            estatisticasEquipe[1].Text);
            //        equipe.Derrotas = Convert.ToInt32(
            //            estatisticasEquipe[2].Text);
            //        equipe.PercentualVitorias =
            //            estatisticasEquipe[3].Text;

            //        conferencia.Equipes.Add(equipe);
            //    }
            //}

            return null;
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
