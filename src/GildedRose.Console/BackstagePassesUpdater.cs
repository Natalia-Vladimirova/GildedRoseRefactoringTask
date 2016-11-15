namespace GildedRose.Console
{
    public class BackstagePassesUpdater : IUpdater
    {
        public void Update(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn <= 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn <= 5)
            {
                IncreaseQuality(item);
            }

            item.SellIn -= 1;

            DropQualityToZeroIfSellInIsNegative(item);
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        
        private void DropQualityToZeroIfSellInIsNegative(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
