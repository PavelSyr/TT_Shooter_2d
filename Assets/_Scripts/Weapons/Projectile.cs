using UnityEngine;

namespace TT_Shooter_2d.Weapons
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        #region Private Fields
        [SerializeField]
        private int m_Damage = 10;

        [SerializeField]
        private float m_Speed = 1.0f;

        [SerializeField]
        private float m_LifeTime = 3.0f;

        [SerializeField]
        private string m_TargetTag;
        #endregion

        #region Implementation of IProjectile
        public void SetDirection(Vector3 dir)
        {
            GetComponent<Rigidbody2D>().velocity = dir * m_Speed;
        }

        public void SetTargetTag(string tag)
        {
            m_TargetTag = tag;
        }
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            Destroy(gameObject, m_LifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(m_TargetTag))
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