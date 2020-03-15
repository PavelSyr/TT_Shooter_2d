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
        private Rigidbody2D m_Ridgidbody;
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

            m_Ridgidbody = GetComponent<Rigidbody2D>();
            if (m_Ridgidbody == null)
            {
                throw new ArgumentNullException(nameof(m_Ridgidbody));
            }
        }

        private void FixedUpdate()
        {
            m_Ridgidbody.velocity = m_Input.Direction * m_Speed;
        }

        //private void Update()
        //{
        //    transform.position += new Vector3(
        //        x: m_Input.Horizontal,
        //        y: m_Input.Vertical,
        //        z: 0) * m_Speed * Time.deltaTime;
        //}
        #endregion
    }
}