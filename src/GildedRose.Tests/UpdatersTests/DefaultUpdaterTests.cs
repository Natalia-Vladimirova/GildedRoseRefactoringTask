using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.UpdatersTests
{
    public class DefaultUpdaterTests
    {
        [TestCase(1, 2, Result = 1)]
        [TestCase(1, 0, Result = 0)]
        [TestCase(0, 10, Result = 8)]
        [TestCase(0, 1, Result = 0)]
        [TestCase(0, 0, Result = 0)]
        public int When_Item_gets_older_then_Quality_decreases(int sellIn, int quality)
        {
            var updater = new DefaultUpdater();
            var item = new Item { Name = "Item", SellIn = sellIn, Quality = quality };

            updater.Update(item);

            return item.Quality;
        }
    }
}
