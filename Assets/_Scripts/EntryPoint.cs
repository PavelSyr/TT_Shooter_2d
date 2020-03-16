using System;
using System.Collections;
using System.Collections.Generic;
using TT_Shooter_2d.Enemies;
using TT_Shooter_2d.Settings;
using TT_Shooter_2d.UI;
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

        [SerializeField]
        private GameObject m_RespawnPoint;

        [SerializeField]
        private GameViews m_GameViews;
#pragma warning restore 0649

        private GameHandler m_Game;
        private IRespawn m_Respawn;

        #region Unity Callbacks
        private void Awake()
        {
            Check();

            Init();

            StartCoroutine(EnemySetup());
        }
        #endregion

        #region Private Methods
        private void Check()
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

            if (m_RespawnPoint == null)
            {
                throw new ArgumentNullException(nameof(m_RespawnPoint));
            }

            if (m_GameViews == null)
            {
                throw new ArgumentNullException(nameof(m_GameViews));
            }

            m_Respawn = m_RespawnPoint.GetComponent<IRespawn>();
            if (m_Respawn == null)
            {
                throw new ArgumentNullException(nameof(m_Respawn));
            }

            m_GameSettings.Check();
        }

        private void Init()
        {
            var playerComponentsToSetup = m_Player.GetComponents<ISetupable>();
            foreach (var component in playerComponentsToSetup)
            {
                component.Setup(m_GameSettings.PlayerSettings);
                component.Setup(m_Respawn);
            }

            m_Game = new GameHandler(m_Player, m_EnemyContainer);

            m_GameViews.Setup(m_Game);
        }

        private IEnumerator EnemySetup()
        {
            m_Game.Wait();
            yield return new WaitForSeconds(m_GameSettings.PauseBeforeEnemyCreation);

            var enemySettings = m_GameSettings.EnemySettings;

            var enemyFactory = new EnemyFactory(m_EnemyContainer, m_GameSettings.EnemyPrefab, enemySettings, m_Player.transform);
            for (int i = 0; i < enemySettings.EnemyCount; i++)
            {
                var enemy = enemyFactory.Instatinate();
                m_Game.AddEnemy(enemy);
                yield return null;
            }
            m_Game.Go();
        }
        #endregion
    }
}