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

        public bool isGameOver;
        public float moneyRemaining;
        public float timeLasted = 0f;
        public static float bonusStartingMoney = 0f;
        public static float moneyEarned = 0f;
        public static bool spamClickActive = true;

        //Scaling
        public static float boosterSpawnWait = 1.5f;
        public static float boosterLifespan = 2f;

        // Upgradable
        public static float lossRate = 2.5f; // In dollars per frame ($10/sec at 0.2)
        public static float boosterWorth = 80f;
        public static float moveSpeed = 8f;
        public static int spamClickTime = 3;
        public static float spamClickValue = 10f;
        public static Color lineColour = new Color(0f, 207f / 255f, 1f, 1f);
        public static bool hasRainbowLine = false;

        [Space(20)]
        [Header("References")]
        [SerializeField] private TextMeshProUGUI moneyRemainingText;
        [SerializeField] private GameObject spamClickButton;
        [SerializeField] private Transform line;


        private void Start()
        {
            isGameOver = false;
            ResetStaticValues();
            Time.timeScale = 1f;
            if (spamClickActive)
            {
                StartCoroutine(SpamClicker());
            }

        }

        private void FixedUpdate()
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
                //Scaling stonk booster spawn wait with time lasted
                if (boosterSpawnWait >= 0.03f) boosterSpawnWait = 1.5f - (timeLasted * 0.035f);

                // Scaling stonk booster lifespan with time lasted
                if (timeLasted <= 20f) boosterLifespan = 2f - (timeLasted * 0.025f); // This will take lifespan down to 1.5s by 20s
                else if (timeLasted <= 40f) boosterLifespan = 2.5f - (timeLasted * 0.05f); // This will take lifespan down to 0.5s by 40s
                Debug.Log(boosterLifespan);
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
            boosterSpawnWait = 1.5f;
            boosterLifespan = 2f;
        }

        private void BoostMoney()
        {
            moneyRemaining += boosterWorth;
            Debug.Log("Money boosted by " + boosterWorth);
        }

        private void DecreaseMoney()
        {
            moneyRemaining -= boosterWorth * 0.6f;
            Debug.Log("Money decreased by " + boosterWorth);
        }

        private void PauseTime()
        {
            Time.timeScale = 0f;
        }

        private void SetEarnedMoney()
        {
            isGameOver = true;
            moneyEarned = (timeLasted * 100) + (line.position.x * 30);
        }

        private void OnEnable()
        {
            EventManager.OnBoosterPickup += BoostMoney;
            EventManager.OnBoosterMiss += DecreaseMoney;
            EventManager.OnGameOver += PauseTime;
            EventManager.OnGameOver += SetEarnedMoney;
        }
        private void OnDisable()
        {
            EventManager.OnBoosterPickup -= BoostMoney;
            EventManager.OnBoosterMiss -= DecreaseMoney;
            EventManager.OnGameOver -= PauseTime;
            EventManager.OnGameOver -= SetEarnedMoney;
        }
    }
}