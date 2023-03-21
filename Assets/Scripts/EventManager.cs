using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void VoidDelegate();
    public static VoidDelegate OnBoosterPickup;
    public static VoidDelegate OnGameOver;
    public static VoidDelegate OnUpgradeBuy;
}
