namespace GildedRose.Console
{
    public interface IUpdaterProvider
    {
        IUpdater GetUpdater(string itemName);
    }
}