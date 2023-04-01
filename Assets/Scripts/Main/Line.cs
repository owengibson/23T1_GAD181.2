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

        private Color32[] colors;

        private void Start()
        {
            trailMat = GetComponent<TrailRenderer>().material;
            headMat = GetComponentInChildren<SpriteRenderer>().material;

            if (!GameManager.hasRainbowLine)
            {
                trailMat.color = GameManager.lineColour;
                trailMat.SetColor("_EmissionColor", GameManager.lineColour);
   
                headMat.color = GameManager.lineColour;
                headMat.SetColor("_EmissionColor", GameManager.lineColour);
            }
            else
            {
                colors = new Color32[7]
                {
                    new Color32(255, 0, 0, 255), //red
                    new Color32(255, 165, 0, 255), //orange
                    new Color32(255, 255, 0, 255), //yellow
                    new Color32(0, 255, 0, 255), //green
                    new Color32(0, 0, 255, 255), //blue
                    new Color32(75, 0, 130, 255), //indigo
                    new Color32(238, 130, 238, 255), //violet
                };
                StartCoroutine(Cycle());
            }

        }
        private void FixedUpdate()
        {
            if (!GameManager.spamClickActive && !GM.isGameOver)
            {
                lineYPos = (GM.moneyRemaining / 100f) - 5;
                lineXPos = line.position.x + (0.01f * GameManager.moveSpeed);

                line.position = new Vector2(lineXPos, lineYPos);
            }
            
        }

        private IEnumerator Cycle()
        {
            //int startColor = 0;
            //int endColor = 0;
            //startColor = Random.Range(0, colors.Length);
            //endColor = Random.Range(0, colors.Length);
            int i = 0;

            while (GameManager.hasRainbowLine)
            {
                for (float interpolant = 0f; interpolant < 1f; interpolant += 0.01f)
                {
                    headMat.color = Color.Lerp(colors[i%7], colors[(i + 1)%7], interpolant);
                    headMat.SetColor("_EmissionColor", Color.Lerp(colors[i%7], colors[(i + 1)%7], interpolant));

                    trailMat.color = Color.Lerp(colors[i%7], colors[(i + 1)%7], interpolant);
                    trailMat.SetColor("_EmissionColor", Color.Lerp(colors[i%7], colors[(i + 1)%7], interpolant));

                    yield return null;
                }
                i++;
            }
        }

        private void OnApplicationQuit()
        {
            GameManager.lineColour = defaultLineColour;
            headMat.color = defaultLineColour;
            headMat.SetColor("_EmissionColour", defaultLineColour);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F12))
            {
                GM.moneyRemaining += 50f;
            }
        }
    }
}