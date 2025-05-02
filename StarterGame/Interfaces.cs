namespace StarterGame{
    public interface Trigger {}

    public interface IWorldEvent{
        Trigger Trigger { get; }

        void Execute();
    }

    public interface IItem{
        string Name { get; set;}
        float Weight { get; set; }
        string Description{get;}
        int ReduceDurability(int amount);
        bool IsBroken { get; set; }
        //void Decorate(IItem decorator); commented out temporarily
    }

    public interface IItemContainer : IItem
    {
        bool Insert(IItem item);

        IItem Remove(string itemName);

    }

}