using System;
using UnityEngine;
using UnityEngine.UI;

namespace TT_Shooter_2d.UI
{
    public class GameViews : MonoBehaviour, ISetupable<GameHandler>
    {
        private const string RESULT_TEXT = "Restult : {0:hh\\:mm\\:ss}\n Enemies : {1}";

#pragma warning disable 0649
        [SerializeField]
        private GameObject m_Wait;

        [SerializeField]
        private GameObject m_Win;

        [SerializeField]
        private GameObject m_Lose;

        [SerializeField]
        private Text m_ResultText;

        private GameHandler m_Game;
#pragma warning restore 0649

        #region Implementation of ISetupable
        public void Setup(GameHandler settings)
        {
            if (m_Game != null)
            {
                m_Game.OnWait -= Game_OnWait;
                m_Game.OnGo -= Game_OnGo;
                m_Game.OnWin -= Game_OnWin;
                m_Game.OnLose -= Game_OnLose;
            }

            m_Game = settings;

            m_Game.OnWait += Game_OnWait;
            m_Game.OnGo += Game_OnGo;
            m_Game.OnWin += Game_OnWin;
            m_Game.OnLose += Game_OnLose;
        }

        public void Setup(object settings)
        {
            var gameHanler = settings as GameHandler;
            if (gameHanler != null)
            {
                Setup(gameHanler);
            }
        }
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            if (m_Wait == null)
            {
                throw new ArgumentNullException(nameof(m_Wait));
            }

            if (m_Win == null)
            {
                throw new ArgumentNullException(nameof(m_Win));
            }

            if (m_Lose == null)
            {
                throw new ArgumentNullException(nameof(m_Lose));
            }

            if (m_ResultText == null)
            {
                throw new ArgumentNullException(nameof(m_ResultText));
            }
        }
        #endregion


        #region Private Methods
        private void Game_OnWin()
        {
            m_ResultText.text = string.Format(RESULT_TEXT, m_Game.PlayTime, m_Game.Count);

            m_Win.SetActive(true);
        }

        private void Game_OnWait()
        {
            m_Wait.SetActive(true);
        }

        private void Game_OnLose()
        {
            m_Lose.SetActive(true);
        }

        private void Game_OnGo()
        {
            m_Wait.SetActive(false);
            m_Win.SetActive(false);
            m_Lose.SetActive(false);
        }
        #endregion
    }
}