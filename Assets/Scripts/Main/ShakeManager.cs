using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Owniel
{
    public class ShakeManager : MonoBehaviour
    {
        private MMF_Player shaker;

        private void Start()
        {
            shaker = GetComponent<MMF_Player>();
        }

        private void Shake()
        {
            shaker.PlayFeedbacks();
        }

        private void OnEnable()
        {
            EventManager.OnBoosterPickup += Shake;
        }
        private void OnDisable()
        {
            EventManager.OnBoosterPickup -= Shake;
        }
    }
}