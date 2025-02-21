using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2  : MonoBehaviour
{
    public GameObject[] goals;
    public GameObject[] boxes;

    void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    void Update()
    {
        Winner();
    }

    bool CheckWinCondition()
    {
        foreach (GameObject goal in goals)
        {
            bool boxOnGoal = false;
            foreach (GameObject box in boxes)
            {
                if (Vector2.Distance(goal.transform.position, box.transform.position) < 0.1f)
                {
                    boxOnGoal = true;
                    break;
                }
            }
            if (!boxOnGoal) return false;
        }
        return true;
    }

    public void Winner()
    {

        if (CheckWinCondition())
        {
            Time.timeScale = 0;
        }
    }
}

