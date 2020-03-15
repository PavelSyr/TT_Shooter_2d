using UnityEngine;

namespace TT_Shooter_2d
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private const string ENEMY_TAG = "Enemy";

        #region Private Fields
        [SerializeField]
        private int m_Damage = 10;

        [SerializeField]
        private float m_Speed = 1.0f;

        [SerializeField]
        private float m_LifeTime = 3.0f;
        #endregion

        #region Implementation of IProjectile
        public void SetDirection(Vector3 dir)
        {
            GetComponent<Rigidbody2D>().velocity = dir * m_Speed;
        }
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            Destroy(gameObject, m_LifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(ENEMY_TAG))
            {
                var damageable = other.gameObject.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    damageable.Damage(m_Damage);
                }

                Destroy(gameObject);
            }
        }
        #endregion
    }
}