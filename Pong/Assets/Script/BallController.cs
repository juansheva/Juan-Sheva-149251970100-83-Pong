using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(Random.Range(0.5f, 1f), Random.Range(0f, 1f));
        rig.velocity = arah * speed;
    }
}