using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject parent;

    [SerializeField] float waitTime;
    [SerializeField] float startTime;
    [SerializeField] float decreaseTime;
    [SerializeField] float minTime = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            GameObject g = Instantiate(enemy, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].transform.position, Quaternion.identity);
            g.transform.parent = parent.transform;
            waitTime = startTime;
            if (startTime > minTime)
            {
                startTime -= decreaseTime;
            }

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
