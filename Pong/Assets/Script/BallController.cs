using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
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
        float arahKananX = Random.Range(1f, 1.5f);
        float arahkiriX = Random.Range(-1.5f, -1f);
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
}