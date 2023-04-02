using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Owniel
{
    public class SpamClickerCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countDownText;

        void Start()
        {
            StartCoroutine(CountdownToText(GameManager.spamClickTime, countDownText));
        }

        private IEnumerator CountdownToText(int count, TextMeshProUGUI text)
        {
            if (!text.gameObject.activeSelf) text.gameObject.SetActive(true);
            else
            {
                for (int i = 0; i < count; i++)
                {
                    text.text = (count - i).ToString();
                    yield return new WaitForSeconds(1);
                }
                text.gameObject.SetActive(false);
                yield break;
            }
        }
    }
}