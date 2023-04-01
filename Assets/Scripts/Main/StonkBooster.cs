using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Owniel
{
    public class StonkBooster : MonoBehaviour
    {
        [SerializeField]
        private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>()
        {
            { "A", KeyCode.A}, { "B", KeyCode.B}, { "C", KeyCode.C}, { "D", KeyCode.D}, { "E", KeyCode.E}, { "F", KeyCode.F},
            { "G", KeyCode.G}, { "H", KeyCode.H}, { "I", KeyCode.I}, { "J", KeyCode.J}, { "K", KeyCode.K}, { "L", KeyCode.L},
            { "M", KeyCode.M}, { "N", KeyCode.N}, { "O", KeyCode.O}, { "P", KeyCode.P}, { "R", KeyCode.R}, { "Q", KeyCode.Q},
            { "S", KeyCode.S}, { "T", KeyCode.T}, { "U", KeyCode.U}, { "V", KeyCode.V}, { "W", KeyCode.W}, { "X", KeyCode.X},
            { "Y", KeyCode.Y}, { "Z", KeyCode.Z}, { "0", KeyCode.Alpha0}, { "1", KeyCode.Alpha1}, { "2", KeyCode.Alpha2},
            { "3", KeyCode.Alpha3}, { "4", KeyCode.Alpha4}, { "5", KeyCode.Alpha5}, { "6", KeyCode.Alpha6}, {"7", KeyCode.Alpha7},
            { "8", KeyCode.Alpha8}, { "9", KeyCode.Alpha9}
        };
        private TextMeshProUGUI keyText;
        private string chosenKey;
        private KeyCode chosenKeyCode;

        private float timeUntilDeath;

        private void Awake()
        {
            chosenKey = keys.ElementAt(Random.Range(0, keys.Count)).Key;
            chosenKeyCode = keys[chosenKey];

            keyText = GetComponentInChildren<TextMeshProUGUI>();
            keyText.text = chosenKey;

            timeUntilDeath = GameManager.boosterLifespan;
        }

        private void Update()
        {
            timeUntilDeath -= Time.deltaTime;
            if (timeUntilDeath <= 0)
            {
                EventManager.OnBoosterMiss?.Invoke();
                Destroy(gameObject);
            }

            if (Input.GetKeyDown(chosenKeyCode))
            {
                EventManager.OnBoosterPickup?.Invoke();
                Destroy(gameObject);
            }

            if (Input.anyKeyDown && !Input.GetKeyDown(chosenKeyCode) && !Input.GetKeyDown(KeyCode.F12))
            {
                EventManager.OnBoosterMiss?.Invoke();
                Destroy(gameObject);
            }
        }

        private void DestroyOnGameOver()
        {
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            EventManager.OnGameOver += DestroyOnGameOver;
        }
        private void OnDisable()
        {
            EventManager.OnGameOver -= DestroyOnGameOver;
        }
    }
}