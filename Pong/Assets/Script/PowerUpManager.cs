using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;

    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;

    [SerializeField]
    private List<GameObject> powerUpList;

    public int spawnInterval;

    private float timer;
    public float powerUpTime;

    [SerializeField]
    private float powerUpTimer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
        //powerUpTimer = powerUpTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //if (powerUpList.Count != 0)
        //{
        //    powerUpTimer -= Time.deltaTime;
        //    if (powerUpTimer <= 0)
        //    {
        //        Destroy(powerUpList[0]);
        //        powerUpList.RemoveAt(0);
        //        powerUpTimer = powerUpTime;
        //    }
        //}

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
        timer = 0;
        //powerUpTimer = powerUpTime;
    }
}