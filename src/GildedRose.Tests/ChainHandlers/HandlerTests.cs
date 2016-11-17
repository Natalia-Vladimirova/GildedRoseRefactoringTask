using GildedRose.Console;
using GildedRose.Console.ChainHandlers;
using NUnit.Framework;

namespace GildedRose.Tests.ChainHandlers
{
    public class HandlerTests
    {
        [TestCase("Aged Brie", 20, Result = 21)]
        [TestCase("Conjured Mana Cake", 20, Result = 18)]
        [TestCase("Usual item", 20, Result = 19)]
        public int When_Handlers_are_called_one_by_one(string itemName, int quality)
        {
            var handlerChain = new Handler("Aged Brie", new AgedBrieUpdater());
            handlerChain.ChainNextHandler(new Handler("Conjured Mana Cake", new ConjuredUpdater()));

            var item = new Item { Name = itemName, SellIn = 10, Quality = quality };

            handlerChain.Handle(item);

            return item.Quality;
        }
    }
}
