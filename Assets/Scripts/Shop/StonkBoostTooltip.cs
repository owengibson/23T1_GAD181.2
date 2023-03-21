using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Owniel
{
    public class StonkBoostTooltip : MonoBehaviour
    {
        [SerializeField] private GameObject stonkBoostTooltip;

        void Start()
        {
            if (stonkBoostTooltip != null)
            {
                stonkBoostTooltip.SetActive(false);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (stonkBoostTooltip != null)
            {
                stonkBoostTooltip.SetActive(true);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (stonkBoostTooltip != null)
            {
                stonkBoostTooltip.SetActive(false);
            }
        }
    }
}