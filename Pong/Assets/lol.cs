using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour
{
    private float[] noiseValues;

    private void Start()
    {
        Random.InitState(42);
        noiseValues = new float[10];
        for (int i = 0; i < noiseValues.Length; i++)
        {
            noiseValues[i] = Random.value;
            Debug.Log(noiseValues[i]);
        }
    }
}