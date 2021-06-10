using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication.demo;
using HtmlAgilityPack;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var vnexpressCrawler = new VnexpressCrawler();
            var listLink = vnexpressCrawler.GetListLink("hhttps://vnexpress.net/suc-khoe");
            for (var i = 0; i < listLink.Count; i++)
            {
                var article = vnexpressCrawler.Crawl(listLink[i]);
                if (article != null)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }

    }
}