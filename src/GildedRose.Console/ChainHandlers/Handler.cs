namespace GildedRose.Console.ChainHandlers
{
    public class Handler : IHandler
    {
        private IHandler nextHandler;

        private readonly IUpdater defaultUpdater;

        private readonly IUpdater updater;

        private readonly string itemName;

        public Handler()
        {
            defaultUpdater = new DefaultUpdater();
            updater = defaultUpdater;
        }

        public Handler(string itemName, IUpdater updater) 
            : this()
        {
            this.itemName = itemName;

            if (updater != null)
            {
                this.updater = updater;
            }
        }

        public IHandler ChainNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
            return this.nextHandler;
        }

        public void Handle(Item item)
        {
            if (item == null) return;

            if (item.Name == itemName)
            {
                updater.Update(item);
                return;
            }

            if (nextHandler != null)
            {
                nextHandler.Handle(item);
                return;
            }

            defaultUpdater.Update(item);
        }
    }
}
