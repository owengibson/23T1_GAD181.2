using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Owniel
{
    public class SpeedTooltip : MonoBehaviour
    {
        [SerializeField] private GameObject speedTooltip;

        void Start()
        {
            if (speedTooltip != null)
            {
                speedTooltip.SetActive(false);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (speedTooltip != null)
            {
                speedTooltip.SetActive(true);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (speedTooltip != null)
            {
                speedTooltip.SetActive(false);
            }
        }
    }
}