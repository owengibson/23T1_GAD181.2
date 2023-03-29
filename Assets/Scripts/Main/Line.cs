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
        [SerializeField] private Color defaultLineColour;

        private Material headMat;
        private Material trailMat;

        private void Start()
        {
            trailMat = GetComponent<TrailRenderer>().material;
            trailMat.color = GameManager.lineColour;
            trailMat.SetColor("_EmissionColor", GameManager.lineColour);

            headMat = GetComponentInChildren<SpriteRenderer>().material;
            headMat.color = GameManager.lineColour;
            headMat.SetColor("_EmissionColor", GameManager.lineColour);
        }
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
        private void OnApplicationQuit()
        {
            GameManager.lineColour = defaultLineColour;
            headMat.color = defaultLineColour;
            headMat.SetColor("_EmissionColour", defaultLineColour);
        }
    }
}