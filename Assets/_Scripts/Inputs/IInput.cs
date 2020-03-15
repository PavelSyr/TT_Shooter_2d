using UnityEngine;

namespace TT_Shooter_2d.Inputs
{
    public delegate void FireHandler();

    interface IInput
    {
        Vector2 Direction { get; }
        float Horizontal { get; }
        float Vertical { get; }
        event FireHandler OnFire;
    }
}
