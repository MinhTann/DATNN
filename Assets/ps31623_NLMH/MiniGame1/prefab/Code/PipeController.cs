using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject gemPrefab;

    private float countDown;
    public float timeDuration;

    public bool startPipe;
    private bool gemSpawned;

    private void Awake()
    {
        countDown = timeDuration;
        startPipe = false;
        gemSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPipe)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                int currentScore = GameObject.Find("main").GetComponent<Bird>().score;

                if (currentScore < 5)
                {
                    Instantiate(pipePrefab, new Vector3(6, Random.Range(1.45f, -2f), 1), Quaternion.identity);
                }
                else if (currentScore >= 5 && !gemSpawned)
                {
                    Debug.Log("Spawn Gem!");
                    Instantiate(gemPrefab, new Vector3(6, 0, 1), Quaternion.identity);
                    gemSpawned = true;
                }

                countDown = timeDuration;
            }
        }
    }
}
