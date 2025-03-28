using System;
using System.Collections.Generic;

namespace BlogObserverExample
{
    public interface ISubscriber
    {
        void Update(string articleTitle);
    }

    public class Blog
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
            Console.WriteLine($"{subscriber.GetType().Name} подписался на блог.");
        }
        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
            Console.WriteLine($"{subscriber.GetType().Name} отписался от блога.");
        }

        public void PublishArticle(string articleTitle)
        {
            Console.WriteLine($"\nБлог: опубликована новая статья \"{articleTitle}\"!");
            NotifySubscribers(articleTitle);
        }

        private void NotifySubscribers(string articleTitle)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(articleTitle);
            }
        }
    }

    public class EmailSubscriber : ISubscriber
    {
        private string _emailAddress;

        public EmailSubscriber(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        public void Update(string articleTitle)
        {
            Console.WriteLine($"Email на {_emailAddress}: новая статья \"{articleTitle}\" опубликована!");
        }
    }
    public class RSSSubscriber : ISubscriber
    {
        private string _feedUrl;

        public RSSSubscriber(string feedUrl)
        {
            _feedUrl = feedUrl;
        }

        public void Update(string articleTitle)
        {
            Console.WriteLine($"RSS канал {_feedUrl}: обновление – новая статья \"{articleTitle}\" опубликована!");
        }
    }
}
