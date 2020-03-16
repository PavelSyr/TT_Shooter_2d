namespace TT_Shooter_2d
{
    public delegate void DieHandler(IDamageable instance);

    public interface IDamageable
    {
        event DieHandler OnDie;
        void Damage(int value);
    }
}
