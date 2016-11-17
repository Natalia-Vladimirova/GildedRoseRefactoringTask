namespace GildedRose.Console
{
    public class BackstagePassesUpdater : DefaultUpdater
    {
        protected override void UpdateQuality(Item item)
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

            DropQualityToZeroIfSellInIsNonPositive(item);
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        
        private void DropQualityToZeroIfSellInIsNonPositive(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
        }
    }
}
