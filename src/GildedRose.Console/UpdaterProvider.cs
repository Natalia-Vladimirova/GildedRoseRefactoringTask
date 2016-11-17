using System.Collections.Generic;

namespace GildedRose.Console
{
    public class UpdaterProvider : IUpdaterProvider
    {
        private readonly Dictionary<string, IUpdater> updaters = new Dictionary<string, IUpdater>();
        private readonly IUpdater defaultUpdater = new DefaultUpdater();
        
        public UpdaterProvider()
        {
            updaters.Add("Aged Brie", new AgedBrieUpdater());
            updaters.Add("Sulfuras, Hand of Ragnaros", new SulfurasUpdater());
            updaters.Add("Backstage passes to a TAFKAL80ETC concert", new BackstagePassesUpdater());
            updaters.Add("Conjured Mana Cake", new ConjuredUpdater());
        }
        
        public IUpdater GetUpdater(string itemName)
        {
            IUpdater result;
            return updaters.TryGetValue(itemName, out result) ? result : defaultUpdater;
        }
    }
}
