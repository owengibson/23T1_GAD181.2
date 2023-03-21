using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Owniel
{
    public class GameManager : MonoBehaviour
    {
        private float startingMoney = 500f;

        public float moneyRemaining;
        public float timeLasted = 0f;

        [Space(20)]
        [Header("Upgradable")]
        public static float lossRate = 0.2f; // In dollars per frame ($10/sec at 0.2)
        public static float boosterWorth = 80f;
        public static float boosterSpawnWait = 1.5f;
        public static float bonusStartingMoney = 0f;

        private void Start()
        {
            moneyRemaining = startingMoney + bonusStartingMoney;
            timeLasted = 0f;
        }

        private void Update()
        {
            timeLasted += Time.deltaTime;
            moneyRemaining -= lossRate;

            if (moneyRemaining <= 0f)
            {
                EventManager.OnGameOver?.Invoke();
            }
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

        private void OnEnable()
        {
            EventManager.OnBoosterPickup += BoostMoney;
            EventManager.OnGameOver += PauseTime;
        }
        private void OnDisable()
        {
            EventManager.OnBoosterPickup -= BoostMoney;
            EventManager.OnGameOver -= PauseTime;
        }
    }
}