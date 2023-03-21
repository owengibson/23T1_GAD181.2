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

        private void Start()
        {
            UpdateWalletText();
        }

        private void UpdateWalletText()
        {
            walletText.text = "$" + GameManager.moneyEarned.ToString("0");
        }

        public void PlayAgain()
        {
            GameManager.bonusStartingMoney = GameManager.moneyEarned / 4f;
            SceneManager.LoadScene("Main");
        }

        public void BuySpeed()
        {
            if (GameManager.moneyEarned >= 1000)
            {
                GameManager.moveSpeed *= 1.25f;
                GameManager.moneyEarned -= 1000;
                UpdateWalletText();
            }
        }

        public void BuyStonkBoost()
        {
            if (GameManager.moneyEarned >= 2000)
            {
                GameManager.boosterWorth *= 1.5f;
                GameManager.moneyEarned -= 2000;
                UpdateWalletText();
            }
        }
    }
}