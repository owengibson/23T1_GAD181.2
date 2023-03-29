using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Owniel
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private GameManager GM;
        private float lineYPos;
        private float lineXPos;
        [SerializeField] private Transform line;
        [SerializeField] private Transform cam;


        private void Update()
        {
            if (!GameManager.spamClickActive && !GM.isGameOver)
            {
                lineYPos = (GM.moneyRemaining / 100f) - 5;
                lineXPos = line.position.x + (0.01f * GameManager.moveSpeed);

                line.position = new Vector2(lineXPos, lineYPos);

                if (Input.GetKeyDown(KeyCode.F12))
                {
                    GM.moneyRemaining += 50f;
                }
            }
            
        }
    }
}