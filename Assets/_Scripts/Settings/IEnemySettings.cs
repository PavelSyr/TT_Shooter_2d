using UnityEngine;

namespace TT_Shooter_2d.Settings
{
    public interface IEnemySettings : IMoveable, IAttackSpeedSettings
    {
        float AttackDistance { get; }
        float DistanceToGo { get; }
        float EnemyCount { get; }
    }
}
