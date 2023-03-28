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

        private void Start()
        {
            UpdateWalletText();
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
            speedText.text = "Speed " + speedLevel.ToString("0") + ": $" + 1000 * speedLevel;
        }
        private void UpdateStonkBoostText()
        {
            stonkBoostText.text = "Stonk boost " + stonkBoostLevel.ToString("0") + ": $" + 2000 * stonkBoostLevel;
        }
        private void UpdateTurboStartText()
        {
            turboStartText.text = "Turbo start " + turboStartLevel.ToString("0") + ": $" + 5000 * turboStartLevel;
        }
        private void UpdateLongStartText()
        {
            longStartText.text = "Long start " + longStartLevel.ToString("0") + ": $" + 7500 * longStartLevel;
        }

        public void PlayAgain()
        {
            GameManager.bonusStartingMoney = GameManager.moneyEarned / 4f;
            SceneManager.LoadScene("Main");
        }

        public void BuySpeed()
        {
            if (GameManager.moneyEarned >= 1000 * speedLevel)
            {
                GameManager.moveSpeed *= 1.25f;
                GameManager.moneyEarned -= 1000;
                UpdateWalletText();

                speedLevel++;
                UpdateSpeedText();
            }
        }

        public void BuyStonkBoost()
        {
            if (GameManager.moneyEarned >= 2000 * stonkBoostLevel)
            {
                GameManager.boosterWorth *= 1.5f;
                GameManager.moneyEarned -= 2000;
                UpdateWalletText();

                stonkBoostLevel++;
                UpdateStonkBoostText();
            }
        }
    }
}