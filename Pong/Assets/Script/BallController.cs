using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public PaddleController paddle;
    public Vector2 resetPosition;

    public int speed;
    private Rigidbody2D rig;

    private void Start()
    {
        resetPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = Vector2.zero;
        float arahKananX = Random.Range(0.5f, 0.7f);
        float arahkiriX = Random.Range(-0.7f, -0.5f);
        int arahPilih = Random.Range(0, 2);
        float arahX;
        if (arahPilih == 1)
        {
            arahX = arahKananX;
        }
        else
        {
            arahX = arahkiriX;
        }
        Vector2 arah = new Vector2(arahX, Random.Range(-1f, 1f));
        rig.velocity = arah * speed;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleController paddleTemp = collision.gameObject.GetComponent<PaddleController>();
        if (paddleTemp != null)
        {
            paddle = paddleTemp;
        }
    }
}