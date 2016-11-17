using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.UpdatersTests
{
    public class BackstagePassesUpdaterTests
    {
        [TestCase(15, 50, Result = 50)]
        [TestCase(11, 20, Result = 21)]
        [TestCase(10, 20, Result = 22)]
        [TestCase(10, 49, Result = 50)]
        [TestCase(6, 20, Result = 22)]
        [TestCase(5, 20, Result = 23)]
        [TestCase(5, 48, Result = 50)]
        [TestCase(0, 20, Result = 0)]
        [TestCase(-1, 20, Result = 0)]
        public int When_BackstagePassesItem_gets_older_then_Quality_increases(int sellIn, int quality)
        {
            var updater = new BackstagePassesUpdater();
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

            updater.Update(item);

            return item.Quality;
        }
    }
}
