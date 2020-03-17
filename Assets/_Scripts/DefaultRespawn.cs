using UnityEngine;

namespace TT_Shooter_2d
{
    public class DefaultRespawn : MonoBehaviour, IRespawn
    {
        [SerializeField]
        private float m_Delay = 2.0f;

        public Vector3 Position => transform.position;

        public float Delay => m_Delay;
    }
}