using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddleSpeed : PowerUpPaddle
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    protected override void Interacted(BallController _ball, int _multiplier, float _duration)
    {
        _ball.paddle.BuffSpeed(_multiplier, _duration);
        base.Interacted(_ball, _multiplier, _duration);
    }
}