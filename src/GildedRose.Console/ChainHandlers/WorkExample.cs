using System.Collections.Generic;

namespace GildedRose.Console.ChainHandlers
{
    public class WorkExample
    {
        private readonly IHandler handlerChain;

        public IList<Item> Items { get; set; }

        public WorkExample()
        {
            (handlerChain = new Handler())
                .ChainNextHandler(new Handler("Aged Brie", new AgedBrieUpdater()))
                .ChainNextHandler(new Handler("Sulfuras, Hand of Ragnaros", new SulfurasUpdater()))
                .ChainNextHandler(new Handler("Backstage passes to a TAFKAL80ETC concert", new BackstagePassesUpdater()))
                .ChainNextHandler(new Handler("Conjured Mana Cake", new ConjuredUpdater()));
        }

        public void UpdateQuality()
        {
            if (Items == null) return;

            foreach (var item in Items)
            {
                handlerChain.Handle(item);
            }
        }
    }
}
