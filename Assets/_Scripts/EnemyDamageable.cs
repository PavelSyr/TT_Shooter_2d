using UnityEngine;

namespace TT_Shooter_2d
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private int m_LifeCount = 1;

        public event DieHandler OnDie;

        public void Damage(int value)
        {
            m_LifeCount--;

            if (m_LifeCount <= 0)
            {
                OnDie?.Invoke(this);

                Destroy(gameObject);
            }
        }
    }
}