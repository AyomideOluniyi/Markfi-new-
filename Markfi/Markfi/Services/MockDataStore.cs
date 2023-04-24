using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markfi.Models;

namespace Markfi.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        /*
         * MockDataStore has been modified to store quiz pack information. This is so that it works with ItemsViewModel. ItemsViewModel then allows
         * the packs to be displayed and lets the user select from the list of packs. It also provides the option for the user to create their own
         * packs, although this function will need to be modified to store a set of questions. Question and Answer packs are NOT stored here, instead
         * pack titles and descriptions are.
         */
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Over 65s Pack",
                    Description="Pack designed for users over the age of 65",
                    TopScore=0
                },

                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Under 10s Pack",
                    Description="Pack designed for users under the age of 10",
                    TopScore=0
                },

                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "TV and Film Pack",
                    Description="Pack themed around TV and Film",
                    TopScore = 0
                },

                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Pop Culture and Movies Pack",
                    Description="Pack designed around Pop Culture and Movies",
                    TopScore = 0
                }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}