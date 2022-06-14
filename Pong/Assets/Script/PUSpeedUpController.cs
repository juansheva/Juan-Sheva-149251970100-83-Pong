using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;

    public Collider2D ball;

    public float magnitude;

    public float powerUpTime;

    private void Start()
    {
        GameObject bola = GameObject.Find("Bola");
        ball = bola.GetComponent<Collider2D>();
        manager = FindObjectOfType<PowerUpManager>();
    }

    private void Update()
    {
        powerUpTime -= Time.deltaTime;
        if (powerUpTime <= 0)
        {
            manager.RemovePowerUp(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            // Speed Up the ball
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}