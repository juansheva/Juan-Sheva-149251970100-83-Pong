using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : MonoBehaviour
{
    public PowerUpManager manager;

    public float duration;
    public int multiplier;

    public float powerUpTime;

    private void Start()
    {
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        BallController ball = other.GetComponent<BallController>();
        if (ball != null)
        {
            Interacted(ball, multiplier, duration);
        }
    }

    protected virtual void Interacted(BallController _ball, int _multiplier, float _duration)
    {
        manager.RemovePowerUp(gameObject);
    }
}