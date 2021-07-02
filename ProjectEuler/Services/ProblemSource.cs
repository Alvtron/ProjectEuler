using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ProjectEuler.Library;

namespace ProjectEuler.Services
{
    public class ProblemSource
    {
        private readonly Dictionary<int, IProblem> cache;

        public ProblemSource()
        {
            this.cache = new Dictionary<int, IProblem>();
        }

        public IProblem GetProblem(int number)
        {
            if (this.cache.TryGetValue(number, out var cachedProblem))
            {
                return cachedProblem;
            }

            var url = CreateProblemUrl(number);
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var titleNode = htmlDoc.DocumentNode.SelectSingleNode("//h2");

            var descriptionNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='problem_content']");

            return this.cache[number] = new Problem(number, titleNode.InnerText, descriptionNode.InnerText);
        }

        private static Uri CreateProblemUrl(int number)
        {
            return new Uri(@$"https://projecteuler.net/problem={number}");
        }
    }
}
