using UnityEngine;

namespace TT_Shooter_2d
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private int m_LifeCount = 1;

        public void Damage(int value)
        {
            m_LifeCount--;

            if (m_LifeCount <= 0)
                Destroy(gameObject);
        }
    }
}