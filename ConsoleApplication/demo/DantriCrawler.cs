using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication.demo
{
    public class DantriCrawler: Crawler
    {
        public Article Crawl(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                var titleNode = doc.DocumentNode.SelectSingleNode("//h3[contains(@class, 'news-item__title')]/a");
                var title = titleNode.InnerText;
                var contentNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'news-item__content')]");
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
            var doc = web.Load("https://dantri.com.vn/suc-khoe.htm");
            var nodeContent = doc.DocumentNode.SelectNodes("/div[contains(@class,'news-item__content')]");
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
                var docTitle = document.DocumentNode.SelectSingleNode("//h3[contains(@class, 'news-item__title')]/a");
                Console.WriteLine(docTitle.InnerText);
            }
            return null;
        }
    }
}