using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Owniel
{
    public class ColourPicker : MonoBehaviour
    {
        public void PickColour()
        {
            Color colour = GetComponent<RawImage>().color;
            GameManager.lineColour = colour;
            transform.parent.gameObject.SetActive(false);
        }
    }
}