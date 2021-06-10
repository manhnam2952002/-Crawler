using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using HtmlAgilityPack;

namespace ConsoleApplication.demo
{
    public class VnexpressCrawler : Crawler
    { public Article Crawl(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                var titleNode = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                var title = titleNode.InnerText;
                var contentNode = doc.DocumentNode.SelectSingleNode("//article[contains(@class, 'fck-detail')]/a");
                var content = contentNode.InnerHtml;
                var imageNode = doc.DocumentNode.SelectSingleNode("//picture/img");
                var image = imageNode.Attributes["src"].Value;
                var article = new Article
                {
                    Title = title,
                    Content = content,
                    Image = image,
                    Url = url
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<string> GetListLink(string listUrl)
        {
            var list = new List<string>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("https://vnexpress.net/giai-tri");
            var nodeContent = doc.DocumentNode.SelectNodes("//h3[contains(@class, 'title-news')]/a");
            Console.WriteLine(nodeContent.Count());
            for (int i = 0; i < nodeContent.Count(); i++)
            {
                var link = nodeContent.ElementAt(i).Attributes["href"].Value;
                list.Add(link);
            }

            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine(list[i]);
                var document = web.Load(list[i]);
                var docTitle = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                Console.WriteLine(docTitle.InnerText);


            }

            return null;

        }
    }
}
