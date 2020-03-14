namespace TT_Shooter_2d.Inputs
{
    public delegate void FireHandler();

    interface IInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        event FireHandler OnFire;
    }
}
