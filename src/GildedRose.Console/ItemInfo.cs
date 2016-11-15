namespace GildedRose.Console
{
    public class ItemInfo
    {
        public Item Item { get; }

        public IUpdater Updater { get; }

        public ItemInfo(Item item, IUpdater updater)
        {
            Item = item;
            Updater = updater;
        }

        public ItemInfo(Item item)
        {
            Item = item;
            Updater = new DefaultUpdater();
        }
    }
}
