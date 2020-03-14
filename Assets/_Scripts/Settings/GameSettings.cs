using System;
using UnityEngine;

namespace TT_Shooter_2d.Settings
{
    [CreateAssetMenu(menuName = "TT_Shooter_2d/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        #region Settings
#pragma warning disable 0649
        [Tooltip("Player settings")]
        [SerializeField]
        private PlayerSettings m_PlayerSettings;

        [Space]
        [Tooltip("Enemy settings")]
        [SerializeField]
        private EnemySettings m_EnemySettings;

        [Space]
        [Tooltip("Enemy prefab")]
        [SerializeField]
        private GameObject m_EnemyPrefab;

#pragma warning restore 0649
        #endregion

        #region Properties;
        public GameObject EnemyPrefab => m_EnemyPrefab;
        public IPlayerSettings PlayerSettings => m_PlayerSettings;
        public IEnemySettings EnemySettings => m_EnemySettings;
        #endregion

        public void Check()
        {
            if (m_EnemyPrefab == null)
            {
                throw new ArgumentNullException(nameof(m_EnemyPrefab));
            }
        }
    }

    [Serializable]
    class PlayerSettings : IPlayerSettings
    {
        public float Speed = 5f;
        public float TurnSpeed = 50.0f;
        public float AttackSpeed = 1f;

        float IPlayerSettings.AttackSpeed => AttackSpeed;
        float IMoveable.Speed => Speed;
        float IMoveable.TurnSpeed => TurnSpeed;
    }


    [Serializable]
    class EnemySettings : IEnemySettings
    {
        public float Speed = 2.5f;
        public float TurnSpeed = 25.0f;
        public float AttackSpeed = 1f;
        public int EnemyCount = 8;
        public float AttackDistance = 0.1f;
        public float DistanceToGo = 2.0f;

        float IEnemySettings.EnemyCount => EnemyCount;
        float IEnemySettings.AttackSpeed => AttackSpeed;
        float IEnemySettings.AttackDistance => AttackDistance;
        float IEnemySettings.DistanceToGo => DistanceToGo;
        float IMoveable.Speed => Speed;
        float IMoveable.TurnSpeed => TurnSpeed;
    }
}