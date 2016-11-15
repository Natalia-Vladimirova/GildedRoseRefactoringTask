namespace GildedRose.Console
{
    public class ConjuredUpdater : IUpdater
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
