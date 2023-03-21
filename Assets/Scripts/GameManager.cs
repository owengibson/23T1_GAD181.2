using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Owniel
{
    public class GameManager : MonoBehaviour
    {
        private float startingMoney = 500f;

        public float moneyRemaining;
        public float timeLasted = 0f;

        public static float lossRate = 0.2f; // In dollars per frame ($10/sec at 0.2)
        public static float boosterWorth = 80f;
        public static float boosterSpawnWait = 1f;
        public static float bonusStartingMoney = 0f;
        public static float moneyEarned = 0f;
        public static float moveSpeed = 1f;

        [Space(20)]
        [Header("References")]
        [SerializeField] private TextMeshProUGUI moneyRemainingText;


        private void Start()
        {
            ResetStaticValues();
            Time.timeScale = 1f;
        }

        private void Update()
        {
            timeLasted += Time.deltaTime;
            moneyRemaining -= lossRate;
            moneyRemainingText.text = "$" + moneyRemaining.ToString("0");

            if (moneyRemaining <= 0f)
            {
                EventManager.OnGameOver?.Invoke();
            }
        }

        private void ResetStaticValues()
        {
            moneyRemaining = startingMoney + bonusStartingMoney;
            bonusStartingMoney = 0f;
            moneyEarned = 0f;
            timeLasted = 0f;
        }

        private void BoostMoney()
        {
            moneyRemaining += boosterWorth;
            Debug.Log("Money boosted by " + boosterWorth);
        }

        private void PauseTime()
        {
            Time.timeScale = 0f;
        }

        private void SetEarnedMoney()
        {
            moneyEarned = timeLasted * 100;
        }

        private void OnEnable()
        {
            EventManager.OnBoosterPickup += BoostMoney;
            EventManager.OnGameOver += PauseTime;
            EventManager.OnGameOver += SetEarnedMoney;
        }
        private void OnDisable()
        {
            EventManager.OnBoosterPickup -= BoostMoney;
            EventManager.OnGameOver -= PauseTime;
            EventManager.OnGameOver -= SetEarnedMoney;
        }
    }
}