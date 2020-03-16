using System;
using TT_Shooter_2d.Settings;
using UnityEngine;

namespace TT_Shooter_2d.Enemies
{
    class EnemyFactory : IEnemyFactory
    {
        private const float RADIUS = 5.0f;

        #region Private Fields
        private Transform m_Container;
        private GameObject m_Prefab;
        private Transform m_Player;
        private IEnemySettings m_Settings;
        #endregion

        public EnemyFactory(Transform container, GameObject prefab, IEnemySettings settings, Transform player)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            m_Container = container;
            m_Prefab = prefab;
            m_Player = player;
            m_Settings = settings;
        }

        #region Implemetation of IEnemyFactory
        public GameObject Instatinate()
        {
            Vector3 origin = m_Player.position + UnityEngine.Random.insideUnitSphere * (RADIUS + m_Settings.DistanceToGo);
            origin.z = 0;

            var enemy = GameObject.Instantiate(m_Prefab, origin, Quaternion.identity, m_Container);

            var componentsToSetup = enemy.GetComponents<ISetupable>();
            foreach (var component in componentsToSetup)
            {
                component.Setup(m_Settings);
                component.Setup(m_Player);
            }

            return enemy;
        }
        #endregion
    }
}
