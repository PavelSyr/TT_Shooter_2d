using System;
using TT_Shooter_2d.Inputs;
using TT_Shooter_2d.Settings;
using UnityEngine;

namespace TT_Shooter_2d
{
    public class CharacterMovier : MonoBehaviour, ISetupable
    {
        [SerializeField]
        private float m_Speed = 5.0f;

        [SerializeField]
        private float m_TrunSpeed = 5.0f;

        #region Private Fields
        private IInput m_Input;
        #endregion

        #region Public Method
        public void Setup(IMoveable playerSettings)
        {
            m_Speed = playerSettings.Speed;
            m_TrunSpeed = playerSettings.TurnSpeed;
        }

        public void Setup(object settings)
        {
            var playerSettings = settings as IMoveable;

            if (playerSettings != null)
            {
                Setup(playerSettings);
            }
        }
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            m_Input = GetComponent<IInput>();

            if (m_Input == null)
            {
                throw new ArgumentNullException(nameof(m_Input));
            }
        }

        private void Update()
        {
            transform.position += m_Input.Vertical * transform.forward * m_Speed * Time.deltaTime;
            transform.Rotate(Vector3.up * m_Input.Horizontal * m_TrunSpeed * Time.deltaTime);
        }
        #endregion
    }
}