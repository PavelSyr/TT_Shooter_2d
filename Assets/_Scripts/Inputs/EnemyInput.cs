using TT_Shooter_2d.Settings;
using UnityEngine;

namespace TT_Shooter_2d.Inputs
{
    public class EnemyInput : MonoBehaviour, IInput, ISetupable<Transform>, ISetupable<IEnemySettings>
    {
        #region Private Fields
        [SerializeField]
        private Transform m_Target;

        [SerializeField]
        private float m_AttakDistance = 0.1f;

        [SerializeField]
        private float m_DistanceToGo = 5.0f;
        #endregion

        #region Properties
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public Vector2 Direction => new Vector2(Horizontal, Vertical).normalized;
        #endregion

        #region Events
        public event FireHandler OnFire;
        #endregion

        #region Implementation of ISetupable
        public void Setup(IEnemySettings settings)
        {
            m_AttakDistance = settings.AttackDistance;
            m_DistanceToGo = settings.DistanceToGo;
        }

        public void Setup(Transform target)
        {
            m_Target = target;
        }

        public void Setup(object settings)
        {
            var target = settings as Transform;
            if (target != null)
            {
                Setup(target);
            }

            var enemySettings = settings as IEnemySettings;
            if (enemySettings != null)
            {
                Setup(enemySettings);
            }
        }
        #endregion

        #region Unity Callbacks
        private void Update()
        {
            var distance = Vector3.Distance(m_Target.position, transform.position);

            if (distance <= m_AttakDistance)
            {
                OnFire?.Invoke();
            }
            else
            {
                //clean input;
                Vertical = 0.0f;
                Horizontal = 0.0f;

                //calculate new
                if (distance <= m_DistanceToGo)
                {
                    var toTargetDirection = (m_Target.position - transform.position).normalized;
                    Horizontal = toTargetDirection.x;
                    Vertical = toTargetDirection.y;
                }
            }
        }
        #endregion
    }
}