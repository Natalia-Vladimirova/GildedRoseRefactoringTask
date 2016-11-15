namespace GildedRose.Console
{
    public class AgedBrieUpdater : IUpdater
    {
        public void Update(Item item)
        {
            IncreaseQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
    }
}
