using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.UpdatersTests
{
    public class SulfurasUpdaterTests
    {
        [TestCase(0, 80, Result = 80)]
        public int When_SulfurasItem_gets_older_then_Quality_is_unchanged(int sellIn, int quality)
        {
            var updater = new SulfurasUpdater();
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality };

            updater.Update(item);

            return item.Quality;
        }
    }
}
