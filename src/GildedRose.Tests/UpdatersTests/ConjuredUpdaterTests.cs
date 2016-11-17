using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.UpdatersTests
{
    public class ConjuredUpdaterTests
    {
        [TestCase(1, 10, Result = 8)]
        [TestCase(1, 1, Result = 0)]
        [TestCase(0, 10, Result = 6)]
        [TestCase(0, 4, Result = 0)]
        [TestCase(0, 3, Result = 0)]
        public int When_ConjuredItem_gets_older_then_Quality_decreases_twice_as_fast_as_normal_items(int sellIn, int quality)
        {
            var updater = new ConjuredUpdater();
            var item = new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };

            updater.Update(item);

            return item.Quality;
        }
    }
}
