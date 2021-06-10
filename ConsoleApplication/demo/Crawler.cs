using System.Collections.Generic;

namespace ConsoleApplication.demo
{
    public interface Crawler
    {
        Article Crawl(string url);

        List<string> GetListLink(string listUrl);
    }
}