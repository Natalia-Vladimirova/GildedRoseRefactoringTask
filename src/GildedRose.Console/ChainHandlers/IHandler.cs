namespace GildedRose.Console.ChainHandlers
{
    public interface IHandler
    {
        void Handle(Item item);

        IHandler ChainNextHandler(IHandler nextHandler);
    }
}
