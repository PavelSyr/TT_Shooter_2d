using UnityEngine;

namespace TT_Shooter_2d
{
    interface IRespawn
    {
        Vector3 Position { get; }
        float Delay { get; }
    }
}
