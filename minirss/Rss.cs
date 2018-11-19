using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace minirss
{
    class Rss
    {
        public async Task<List<Feed>> GetAllFeeds()
        {
            var list = new List<Feed>();

            string[] feedUrls =
            {
                "https://news.ycombinator.com/rss",
                "https://www.reddit.com/r/ProgrammerHumor/.rss"
            };

            foreach (var feedUrl in feedUrls)
            {
                list.Add(await FeedReader.ReadAsync(feedUrl));
            }

            return list;
        }
        
        public async Task<List<MiniFeedItem>> GetAllItemsFromAllFeeds()
        {
            var feeds = await this.GetAllFeeds();
            var itemsList = new List<MiniFeedItem>();
            foreach (var feed in feeds)
            {
                foreach (var item in feed.Items)
                {
                    var miniFeedItem = MiniFeedItem.Wrap(item);
                    miniFeedItem.ImageUrl = feed.ImageUrl;
                    itemsList.Add(miniFeedItem);
                }
            }

            return itemsList;
        }
    }
}
