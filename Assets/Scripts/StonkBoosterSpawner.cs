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

        private float timeSinceSpawn;
        private GameObject activeBooster;

        private void Start()
        {
            timeSinceSpawn = 0f;
        }
        private void Update()
        {
            timeSinceSpawn += Time.deltaTime;

            if (timeSinceSpawn >= GameManager.boosterSpawnWait && activeBooster == null)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-600f, 660f), Random.Range(-220f, 270f));
                Quaternion spawnRot = Quaternion.Euler(0, 0, Random.Range(-30f, 30f));

                activeBooster = Instantiate(stonkBoosterPrefab, canvas);
                activeBooster.transform.localPosition = spawnPos;
                activeBooster.transform.localRotation = spawnRot;

                timeSinceSpawn = 0f;
            }
        }
    }
}