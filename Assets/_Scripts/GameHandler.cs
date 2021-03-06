﻿using System;
using System.Collections.Generic;
using TT_Shooter_2d.CrossCutting.Time;
using UnityEngine;

namespace TT_Shooter_2d
{
    public delegate void WaitHandler();
    public delegate void GoHandler();
    public delegate void WinHandler();
    public delegate void LoseHanler();

    public class GameHandler
    {
        #region Events
        public event WinHandler OnWin;
        public event LoseHanler OnLose;
        public event WaitHandler OnWait;
        public event GoHandler OnGo;
        #endregion

        #region Private Fields
        private IDamageable m_Player;
        private List<IDamageable> m_Enemies;
        private Transform m_EnemyContainer;
        private DateTime m_StartTime;
        #endregion

        #region Properties
        public TimeSpan PlayTime { get; private set; }
        public int Count { get; private set; }
        #endregion

        public GameHandler(GameObject player, Transform enemyContainer)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (enemyContainer == null)
            {
                throw new ArgumentNullException(nameof(enemyContainer));
            }

            m_Player = player.GetComponent<IDamageable>();

            if (m_Player == null)
            {
                throw new ArgumentNullException(nameof(m_Player));
            }

            m_Enemies = new List<IDamageable>();
            m_EnemyContainer = enemyContainer;

            m_Player.OnDie += Player_OnDie;
        }

        #region Public Methods
        public void AddEnemy(GameObject enemy)
        {
            var damagable = enemy.GetComponent<IDamageable>();
            if (damagable != null)
            {
                m_Enemies.Add(damagable);
                damagable.OnDie += Damagable_OnDie;
            }
        }

        public void Wait()
        {
            OnWait?.Invoke();
            m_EnemyContainer.gameObject.SetActive(false);
        }

        public void Go()
        {
            m_StartTime = TimeProvider.Current.Now;
            Count = 0;

            OnGo?.Invoke();
            m_EnemyContainer.gameObject.SetActive(true);
        }
        #endregion

        #region Private Methods
        private void Damagable_OnDie(IDamageable instance)
        {
            m_Enemies.Remove(instance);
            Count++;

            instance.OnDie -= Damagable_OnDie;
            if (m_Enemies.Count == 0)
            {
                PlayTime = TimeProvider.Current.Now - m_StartTime;

                OnWin?.Invoke();
            }
        }

        private void Player_OnDie(IDamageable instance)
        {
            m_EnemyContainer.gameObject.SetActive(false);

            instance.OnDie -= Player_OnDie;

            OnLose?.Invoke();
        }
        #endregion
    }
}
