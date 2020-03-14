using UnityEngine;

namespace TT_Shooter_2d.Settings
{
    public interface IEnemySettings : IMoveable
    {
        float AttackSpeed { get; }
        float AttackDistance { get; }
        float DistanceToGo { get; }
        float EnemyCount { get; }
    }
}
