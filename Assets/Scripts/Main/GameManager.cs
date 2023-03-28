using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Owniel
{
    public class GameManager : MonoBehaviour
    {
        private float startingMoney = 500f;
        private int spamClickCounter = 0;


        public float moneyRemaining;
        public float timeLasted = 0f;
        public static float bonusStartingMoney = 0f;
        public static float moneyEarned = 0f;
        public static bool spamClickActive = true;

        // Upgradable
        public static float lossRate = 0.25f; // In dollars per frame ($10/sec at 0.2)
        public static float boosterWorth = 80f;
        public static float boosterSpawnWait = 1f;
        public static float moveSpeed = 1f;
        public static float spamClickTime = 3f;
        public static float spamClickValue = 10f;

        [Space(20)]
        [Header("References")]
        [SerializeField] private TextMeshProUGUI moneyRemainingText;
        [SerializeField] private GameObject spamClickButton;


        private void Start()
        {
            ResetStaticValues();
            Time.timeScale = 1f;
            if (spamClickActive)
            {
                StartCoroutine(SpamClicker());
            }

        }

        private void Update()
        {
            if (!spamClickActive)
            {
                timeLasted += Time.deltaTime;
                moneyRemaining -= lossRate;
                moneyRemainingText.text = "$" + moneyRemaining.ToString("0");

                if (moneyRemaining <= 0f)
                {
                    EventManager.OnGameOver?.Invoke();
                }
            }            
        }

        private IEnumerator SpamClicker()
        {
            spamClickButton.SetActive(true);
            yield return new WaitForSeconds(spamClickTime);
            spamClickButton.SetActive(false);
            spamClickActive = false;
            moneyRemaining += spamClickCounter * spamClickValue;
        }

        public void IncrementSpamClickCounter()
        {
            spamClickCounter++;
        }

        private void ResetStaticValues()
        {
            moneyRemaining = startingMoney + bonusStartingMoney;
            bonusStartingMoney = 0f;
            moneyEarned = 0f;
            timeLasted = 0f;
            spamClickActive = true;
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