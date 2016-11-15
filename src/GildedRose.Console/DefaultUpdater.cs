namespace GildedRose.Console
{
    public class DefaultUpdater : IUpdater
    {
        public void Update(Item item)
        {
            DecreaseQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
}
