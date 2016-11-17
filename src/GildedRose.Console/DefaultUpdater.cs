namespace GildedRose.Console
{
    public class DefaultUpdater : IUpdater
    {
        public void Update(Item item)
        {
            if (item == null) return;

            UpdateQuality(item);
            UpdateSellIn(item);
        }

        protected virtual void UpdateQuality(Item item)
        {
            DecreaseQuality(item);

            if (item.SellIn <= 0)
            {
                DecreaseQuality(item);
            }
        }

        protected virtual void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
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
