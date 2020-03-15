﻿using System;
using System.Collections;
using System.Collections.Generic;
using TT_Shooter_2d.Inputs;
using TT_Shooter_2d.Settings;
using UnityEngine;

namespace TT_Shooter_2d
{
    public class ProjectileLauncher : MonoBehaviour, ISetupable
    {
        #region Private Fields
#pragma warning disable 0649
        [SerializeField]
        private GameObject m_Prefab;

        [SerializeField]
        private Transform m_SpawnPoint;

        [SerializeField]
        private Transform m_Container;

        private IInput m_Input;
#pragma warning restore 0649

        [SerializeField]
        private float m_AttackSpeed;

        private float m_Time = 0.0f;

        private bool m_CanLaunch;
        #endregion

        #region Properties
        private float Delay => 1.0f / m_AttackSpeed;
        #endregion


        #region Implementation of ISetupable
        public void Setup(object settings)
        {
            var playerSettings = settings as IPlayerSettings;

            if (playerSettings != null)
            {
                m_AttackSpeed = playerSettings.AttackSpeed;
            }
        }
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            if (m_Prefab == null)
            {
                throw new ArgumentNullException(nameof(m_Prefab));
            }

            m_Input = GetComponent<IInput>();

            if (m_Input == null)
            {
                throw new ArgumentNullException(nameof(m_Input));
            }

            m_Input.OnFire += Input_OnFire;
        }

        private void Update()
        {
            m_Time += Time.deltaTime;

            if (m_Time >= Delay)
            {
                m_Time = 0;
                m_CanLaunch = true;
            }
        }
        #endregion

        private void Input_OnFire()
        {
            if (m_CanLaunch)
            {
                m_CanLaunch = false;

                //TODO use pool to get instance of bullet
                var go = GameObject.Instantiate(m_Prefab, m_SpawnPoint.position, Quaternion.identity, m_Container);
                var projectile = go.GetComponent<IProjectile>();

                var dir = m_Input.Direction;
                if (dir.sqrMagnitude == 0.0)
                {
                    dir = Vector3.up;
                }
                projectile.SetDirection(dir);
            }
        }
    }
}