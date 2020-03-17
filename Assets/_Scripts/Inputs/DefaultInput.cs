using UnityEngine;

namespace TT_Shooter_2d.Inputs
{
    public class DefaultInput : MonoBehaviour, IInput
    {
        #region Private Constants
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        private const string FIRE = "Fire1";
        #endregion

        #region Properties
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public Vector2 Direction => new Vector2(Horizontal, Vertical).normalized;
        #endregion

        #region Events
        public event FireHandler OnFire;
        #endregion

        #region Unity Callbacks
        private void Update()
        {
            Horizontal = Input.GetAxis(HORIZONTAL);
            Vertical = Input.GetAxis(VERTICAL);

            if (Input.GetButtonDown(FIRE))
                OnFire?.Invoke();
        } 
        #endregion
    }
}