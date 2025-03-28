using System;
using BlogObserverExample;

namespace BlogObserverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Blog blog = new Blog();

            ISubscriber emailSubscriber = new EmailSubscriber("user@example.com");
            ISubscriber rssSubscriber = new RSSSubscriber("https://example.com/rss");

            blog.Subscribe(emailSubscriber);
            blog.Subscribe(rssSubscriber);

            blog.PublishArticle("Принципы паттернов проектирования");

            blog.Unsubscribe(rssSubscriber);


            blog.PublishArticle("Наблюдатель (Observer) в C#");

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
