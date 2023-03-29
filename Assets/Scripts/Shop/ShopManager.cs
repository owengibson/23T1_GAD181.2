using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Owniel
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI walletText;

        [Space(20)]
        [Header("Upgrade Text References")]
        [SerializeField] private TextMeshProUGUI speedText;
        [SerializeField] private TextMeshProUGUI stonkBoostText;
        [SerializeField] private TextMeshProUGUI turboStartText;
        [SerializeField] private TextMeshProUGUI longStartText;

        [Space(20)]
        [Header("Other References")]
        [SerializeField] private GameObject colourPicker;

        private static int speedLevel = 1;
        private static int stonkBoostLevel = 1;
        private static int turboStartLevel = 1;
        private static int longStartLevel = 1;

        private int speedCost = 1000;
        private int stonkBoostCost = 2000;
        private int turboStartCost = 5000;
        private int longStartCost = 7500;
        private int lineColourCost = 20000;
        private int rainbowLineCost = 100000;


        private void Start()
        {
            UpdateWalletText();
            UpdateUpgradeLevelText();
        }

        private void UpdateWalletText()
        {
            walletText.text = "$" + GameManager.moneyEarned.ToString("0");
        }

        private void UpdateUpgradeLevelText()
        {
            UpdateSpeed();
            UpdateStonkBoost();
            UpdateTurboStart();
            UpdateLongStart();
        }

        private void UpdateSpeed()
        {
            speedCost = speedLevel * 1000;
            speedText.text = "Speed " + speedLevel.ToString("0") + ": $" + speedCost;
        }
        private void UpdateStonkBoost()
        {
            stonkBoostCost = stonkBoostLevel * 2000;
            stonkBoostText.text = "Stonk boost " + stonkBoostLevel.ToString("0") + ": $" + stonkBoostCost;
        }
        private void UpdateTurboStart()
        {
            turboStartCost = turboStartLevel * 5000;
            turboStartText.text = "Turbo start " + turboStartLevel.ToString("0") + ": $" + turboStartCost;
        }
        private void UpdateLongStart()
        {
            longStartCost = longStartLevel * 7500;
            longStartText.text = "Long start " + longStartLevel.ToString("0") + ": $" + longStartCost;
        }

        public void PlayAgain()
        {
            GameManager.bonusStartingMoney = GameManager.moneyEarned / 4f;
            SceneManager.LoadScene("Main");
        }

        public void BuySpeed()
        {
            if (GameManager.moneyEarned >= speedCost)
            {
                GameManager.moveSpeed += 0.3f;
                GameManager.moneyEarned -= speedCost;
                UpdateWalletText();

                speedLevel++;
                UpdateSpeed();
            }
        }

        public void BuyStonkBoost()
        {
            if (GameManager.moneyEarned >= stonkBoostCost)
            {
                GameManager.boosterWorth *= 1.25f;
                GameManager.moneyEarned -= stonkBoostCost;
                UpdateWalletText();

                stonkBoostLevel++;
                UpdateStonkBoost();
            }
        }

        public void BuyTurboStart()
        {
            if (GameManager.moneyEarned >= turboStartCost)
            {
                GameManager.spamClickValue *= 2f;
                GameManager.moneyEarned -= turboStartCost;
                UpdateWalletText();

                turboStartLevel++;
                UpdateTurboStart();
            }
        }

        public void BuyLongStart()
        {
            if (GameManager.moneyEarned >= longStartCost)
            {
                GameManager.spamClickTime += 2f;
                GameManager.moneyEarned -= longStartCost;
                UpdateWalletText();

                longStartLevel++;
                UpdateLongStart();
            }
        }

        public void BuyLineColour()
        {
            if (GameManager.moneyEarned >= lineColourCost)
            {
                colourPicker.SetActive(true);
                GameManager.moneyEarned -= lineColourCost;
                UpdateWalletText();
            }
        }

        public void BuyRainbowLine()
        {
            if (GameManager.moneyEarned >= rainbowLineCost && !GameManager.hasRainbowLine)
            {
                GameManager.hasRainbowLine = true;
                GameManager.moneyEarned -= rainbowLineCost;
                UpdateWalletText();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                GameManager.moneyEarned += 10000;
                UpdateWalletText();
            }
        }
    }
}