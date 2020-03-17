using UnityEngine;

namespace TT_Shooter_2d.Weapons
{
    interface IProjectile
    {
        void SetDirection(Vector3 dir);
        void SetTargetTag(string tag);
    }
}
