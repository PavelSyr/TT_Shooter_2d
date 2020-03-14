using System;
using System.Collections;
using System.Collections.Generic;
using TT_Shooter_2d.Enemies;
using TT_Shooter_2d.Settings;
using UnityEngine;

namespace TT_Shooter_2d
{
    public class EntryPoint : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private GameSettings m_GameSettings;

        [SerializeField]
        private GameObject m_Player;

        [SerializeField]
        private Transform m_EnemyContainer;
#pragma warning restore 0649

        #region Unity Callbacks
        private void Awake()
        {
            if (m_GameSettings == null)
            {
                throw new ArgumentNullException(nameof(m_GameSettings));
            }

            if (m_Player == null)
            {
                throw new ArgumentNullException(nameof(m_Player));
            }

            if (m_EnemyContainer == null)
            {
                throw new ArgumentNullException(nameof(m_EnemyContainer));
            }

            m_GameSettings.Check();

            var playerComponentsToSetup = m_Player.GetComponents<ISetupable>();
            foreach(var component in playerComponentsToSetup)
            {
                component.Setup(m_GameSettings.PlayerSettings);
            }

            var enemySettings = m_GameSettings.EnemySettings;

            var enemyFactory = new EnemyFactory(m_EnemyContainer, m_GameSettings.EnemyPrefab, enemySettings, m_Player.transform);
            for (int i = 0; i < enemySettings.EnemyCount; i++)
            {
                enemyFactory.Instatinate();
            }
        }
        #endregion
    }
}