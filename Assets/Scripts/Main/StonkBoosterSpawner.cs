using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Owniel
{
    public class StonkBoosterSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform canvas;
        [SerializeField] private GameObject stonkBoosterPrefab;

        private float timeSinceLastBooster;
        private GameObject activeBooster;

        private void Start()
        {
            timeSinceLastBooster = 0f;
        }
        private void Update()
        {
            if (!GameManager.spamClickActive)
            {
                timeSinceLastBooster += Time.deltaTime;

                if (timeSinceLastBooster >= GameManager.boosterSpawnWait && activeBooster == null)
                {
                    Vector2 spawnPos = new Vector2(Random.Range(-600f, 660f), Random.Range(-220f, 270f));
                    Quaternion spawnRot = Quaternion.Euler(0, 0, Random.Range(-30f, 30f));

                    activeBooster = Instantiate(stonkBoosterPrefab, canvas);
                    activeBooster.transform.localPosition = spawnPos;
                    activeBooster.transform.localRotation = spawnRot;
                    activeBooster.transform.SetAsFirstSibling();
                }
            }
        }

        private void ResetTimeSinceLastBooster()
        {
            timeSinceLastBooster = 0f;
        }
        private void OnEnable()
        {
            EventManager.OnBoosterMiss += ResetTimeSinceLastBooster;
            EventManager.OnBoosterPickup += ResetTimeSinceLastBooster;
        }
        private void OnDisable()
        {
            EventManager.OnBoosterMiss -= ResetTimeSinceLastBooster;
            EventManager.OnBoosterPickup -= ResetTimeSinceLastBooster;
        }
    }
}