using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private float moneyRemaining;
    private float lineYPos;
    private float lineXPos;
    [SerializeField] private Transform line;
    [SerializeField] private Transform cam;

    private void Start()
    {
        moneyRemaining = 200f;
    }

    private void Update()
    {
        moneyRemaining -= 0.2f; // Lose $0.20 every frame

        lineYPos = moneyRemaining / 100f;
        lineXPos = line.position.x + 0.01f;

        line.position = new Vector2(lineXPos, lineYPos);

        if (Input.GetKeyDown(KeyCode.F12))
        {
            moneyRemaining += 50f;
        }
    }

    private void LateUpdate()
    {
        //if (line.position.x >= 0)
        //{
        //    cam.position = new Vector2(line.position.x, cam.position.y);
        //}
    }
}
