using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D ball;
    public List<PaddleController> controllers;
    public bool isRight;
    public ScoreManager manager;

    private void Start()
    {
        PaddleController[] paddle = FindObjectsOfType<PaddleController>();
        foreach (PaddleController paddleController in paddle)
        {
            controllers.Add(paddleController);
        }
        //controllers = FindObjectsOfType<PaddleController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (isRight)
            {
                manager.AddLeftScore(1);
            }
            else
            {
                manager.AddRightScore(1);
            }
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].NormalizedBuff();
            }
            FindObjectOfType<PowerUpManager>().RemoveAllPowerUp();
        }
    }
}