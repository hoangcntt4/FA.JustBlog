using FA.JustBlog.Commom;
using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogInitializer: CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);

            Category category = new Category()
            {
                
                Name = "Apple",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                  
                        Title="Best true wireless earbuds for 2021",
                        ShortDescription="True wireless earbuds are all the rage. Here are the top wire-free models you can buy right now",
                        PostContent="The market for a true wireless earbud has exploded over the last few years. Sure, Apple's AirPods and AirPods Pro remain best sellers in the category, but plenty of excellent competitors are available, several of which are new for 2021 and offer superior audio quality, battery life and performance. And some of these buds are more suited for Android users who can't take advantage of the AirPods' and AirPods Pro's Apple-only features such as hands-free Siri and spatial audio with head-tracking, in the case of the AirPods Pro.",
                        Published=true,
                        UrlSlug="Apple1",
                        PostedOn=DateTime.Now,
                        Modified=DateTime.Now
                    },
                     new Post()
                    {
                     
                        Title="Best fitness trackers for 2021",
                        ShortDescription="Fitbit, Apple and more: Five options to help kick your fitness routine into high gear.",
                        PostContent="A fitness tracker can be a great way to help you get -- or stay -- in shape without needing an all-out smartwatch. A fitness tracker holds you accountable for your physical activity with health and fitness features, such as sleep tracking, heart-rate monitoring, connected GPS and other insights into your daily activities. Your fitness tracking data is then shared with an app to give you a better view of your overall fitness.",
                        Published=true,
                        UrlSlug="Apple2",
                        PostedOn=DateTime.Now,
                        Modified=DateTime.Now
                    },
                     new Post()
                    {
                       
                        Title="Best AirPods deals before Black",
                        ShortDescription="Friday: New AirPods Pro hit $190, $89 AirPods 2 coming soon",
                        PostContent="AirPods are once again at the top of a lot of holiday wishlists, but the landscape for Apple headphones has changed drastically over the past few weeks, as we approach Black Friday. Here's what's new and notable in the world of AirPods",
                        Published=true,
                        UrlSlug="Apple3",
                        PostedOn=DateTime.Now,
                        Modified=DateTime.Now
                    }
                }
            };
            Tag tag = new Tag()
            {
              
                Name = "Best true wireless",
                PostTagMaps = new List<PostTagMap>() { new PostTagMap() { PostId = 1, TagId = 1 } }
            };
            context.Categories.Add(category);
            context.Tags.Add(tag);
            context.SaveChanges();
        }
    }
}
