namespace GildedRose.Console
{
    public class ConjuredUpdater : DefaultUpdater
    {
        protected override void UpdateQuality(Item item)
        {
            DecreaseQuality(item);

            if (item.SellIn <= 0)
            {
                DecreaseQuality(item);
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 1)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
