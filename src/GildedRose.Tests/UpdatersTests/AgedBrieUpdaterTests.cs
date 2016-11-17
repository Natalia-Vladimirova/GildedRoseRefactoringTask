using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.UpdatersTests
{
    public class AgedBrieUpdaterTests
    {
        [TestCase(1, 49, Result = 50)]
        [TestCase(1, 50, Result = 50)]
        [TestCase(0, 10, Result = 12)]
        [TestCase(0, 49, Result = 50)]
        [TestCase(0, 50, Result = 50)]
        public int When_AgedBrieItem_gets_older_then_Quality_increases(int sellIn, int quality)
        {
            var updater = new AgedBrieUpdater();
            var item = new Item {Name = "Aged Brie", SellIn = sellIn, Quality = quality};

            updater.Update(item);

            return item.Quality;
        }
    }
}
