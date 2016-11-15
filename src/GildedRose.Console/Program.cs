using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public static IList<ItemInfo> Items { get; set; }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}),
                new ItemInfo(new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}, new AgedBrieUpdater()),
                new ItemInfo(new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}),
                new ItemInfo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}, new SulfurasUpdater()),
                new ItemInfo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}, new BackstagePassesUpdater()),
                new ItemInfo(new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}, new ConjuredUpdater())
            };

            UpdateQuality();

            System.Console.ReadKey();

        }

        public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Updater.Update(Items[i].Item);
            }
        }
    }
}
