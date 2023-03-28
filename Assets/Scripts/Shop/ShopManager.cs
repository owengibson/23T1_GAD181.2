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

        private static int speedLevel = 1;
        private static int stonkBoostLevel = 1;
        private static int turboStartLevel = 1;
        private static int longStartLevel = 1;

        private static int speedCost = 1000;
        private static int stonkBoostCost = 2000;
        private static int turboStartCost = 5000;
        private static int longStartCost = 7500;

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
            UpdateSpeedText();
            UpdateStonkBoostText();
            UpdateTurboStartText();
            UpdateLongStartText();
        }

        private void UpdateSpeedText()
        {
            speedText.text = "Speed " + speedLevel.ToString("0") + ": $" + speedCost;
        }
        private void UpdateStonkBoostText()
        {
            stonkBoostText.text = "Stonk boost " + stonkBoostLevel.ToString("0") + ": $" + stonkBoostCost;
        }
        private void UpdateTurboStartText()
        {
            turboStartText.text = "Turbo start " + turboStartLevel.ToString("0") + ": $" + turboStartCost;
        }
        private void UpdateLongStartText()
        {
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
                GameManager.moveSpeed *= 1.25f;
                GameManager.moneyEarned -= speedCost;
                UpdateWalletText();

                speedLevel++;
                speedCost += 1000;
                UpdateSpeedText();
            }
        }

        public void BuyStonkBoost()
        {
            if (GameManager.moneyEarned >= stonkBoostCost)
            {
                GameManager.boosterWorth *= 1.5f;
                GameManager.moneyEarned -= stonkBoostCost;
                UpdateWalletText();

                stonkBoostLevel++;
                stonkBoostCost += 2000;
                UpdateStonkBoostText();
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
                turboStartCost += 5000;
                UpdateTurboStartText();
            }
        }

        public void BuyLongStart()
        {
            if (GameManager.moneyEarned >= longStartCost)
            {
                GameManager.spamClickTime += 3f;
                GameManager.moneyEarned -= longStartCost;
                UpdateWalletText();

                longStartLevel++;
                longStartCost += 7500;
                UpdateLongStartText();
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