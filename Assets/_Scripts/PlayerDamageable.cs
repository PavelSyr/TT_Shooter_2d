using UnityEngine;

namespace TT_Shooter_2d
{
    public class PlayerDamageable : MonoBehaviour, IDamageable, ISetupable<Transform>
    {
        [SerializeField]
        private int m_LifeCount = 3;

        [SerializeField]
        private Transform m_Respawn;

        public event DieHandler OnDie;

        public void Damage(int value)
        {
            m_LifeCount--;

            Respawn();

            if (m_LifeCount <= 0)
            {
                OnDie?.Invoke(this);
            }
        }

        #region Implementation of ISetupable
        public void Setup(Transform respawn)
        {
            m_Respawn = respawn;
        }

        public void Setup(object settings)
        {
            var respawn = settings as Transform;

            if (respawn != null)
            {
                Setup(respawn);
            }
        }
        #endregion

        private void Respawn()
        {
            transform.position = m_Respawn.position;
        }
    }
}