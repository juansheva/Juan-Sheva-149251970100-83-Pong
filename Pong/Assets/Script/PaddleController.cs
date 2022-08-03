using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public string arah;
    public int speed;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    public Vector3 normalTransform;
    private int normalSpeed;

    public float edgeField;

    private void Start()
    {
        normalSpeed = speed;
        normalTransform = transform.localScale;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.y >= edgeField || transform.position.y <= -edgeField)
        {
            MoveObject(Vector2.zero);
            if (transform.position.y > edgeField)
            {
                transform.position = new Vector2(transform.position.x, edgeField - 0.01f);
            }
            if (transform.position.y < -edgeField)
            {
                transform.position = new Vector2(transform.position.x, -edgeField + 0.01f);
            }
        }
        else
        {
            MoveObject(GetInput());
        }

        Debug.Log("Kecepatan paddle " + arah + rig.velocity);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    public void BuffSpeed(int _buffMultiplier, float _duration)
    {
        StartCoroutine(PaddleBuffSpeed(_buffMultiplier, _duration));
    }

    public void BuffHeight(int _buffMultiplier, float _duration)
    {
        StartCoroutine(PaddleBuffHeight(_buffMultiplier, _duration));
    }

    private IEnumerator PaddleBuffHeight(int _buffMultiplier, float _duration)
    {
        edgeField /= 1.5f;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * _buffMultiplier, transform.localScale.z);
        yield return new WaitForSeconds(_duration);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / _buffMultiplier, transform.localScale.z);
        edgeField *= 1.5f;
    }

    private IEnumerator PaddleBuffSpeed(int _buffMultiplier, float _duration)
    {
        speed *= _buffMultiplier;
        yield return new WaitForSeconds(_duration);
        speed /= _buffMultiplier;
    }

    public void NormalizedBuff()
    {
        StopAllCoroutines();
        speed = normalSpeed;
        transform.localScale = normalTransform;
        Debug.Log("Normal");
    }
}