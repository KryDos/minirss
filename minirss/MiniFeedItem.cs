using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minirss
{
    class MiniFeedItem : CodeHollow.FeedReader.FeedItem
    {
        public string ImageUrl { get; set; }

        public static MiniFeedItem Wrap(CodeHollow.FeedReader.FeedItem item)
        {
            var miniItem = new MiniFeedItem();
            miniItem.Author = item.Author;
            miniItem.Categories = item.Categories;
            miniItem.Content = item.Content;
            miniItem.Description = item.Description;
            miniItem.Id = item.Id;
            miniItem.Link = item.Link;
            miniItem.PublishingDate = item.PublishingDate;
            miniItem.PublishingDateString = item.PublishingDateString;
            miniItem.SpecificItem = item.SpecificItem;
            miniItem.Title = item.Title;

            return miniItem;
        }
    }
}
