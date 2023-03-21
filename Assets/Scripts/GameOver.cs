using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Owniel
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI earnedText;

        private void Start()
        {
            gameOverPanel.SetActive(false);
        }

        private void InitialiseGameOverScreen()
        {
            gameOverPanel.SetActive(true);
            earnedText.text = "$" + GameManager.moneyEarned.ToString("0");
        }

        public void ProceedToShop()
        {
            SceneManager.LoadScene("Shop");
        }

        public void RestartWithBonusMoney()
        {
            GameManager.bonusStartingMoney = GameManager.moneyEarned;
            SceneManager.LoadScene("Main");
        }

        private void OnEnable()
        {
            EventManager.OnGameOver += InitialiseGameOverScreen;
        }
        private void OnDisable()
        {
            EventManager.OnGameOver -= InitialiseGameOverScreen;
        }
    }
}