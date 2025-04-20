namespace StarterGame{
    public interface Trigger {}

    public interface IWorldEvent{
        Trigger Trigger { get; }

        void Execute();
    }

    public interface IItem{
        string Name { get; set;}
        float Weight{get;set;}
        string Description{get;}
    }

}