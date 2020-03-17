namespace TT_Shooter_2d
{
    interface ISetupable
    {
        void Setup(object settings);
    }

    interface ISetupable<T> : ISetupable
    {
        void Setup(T settings);
    }
}
