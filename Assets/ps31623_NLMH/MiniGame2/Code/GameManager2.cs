using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2  : MonoBehaviour
{
    public GameObject[] goals;
    public GameObject[] boxes;
    public GameObject exitButton;
    public GameObject notific;

    private void Awake()
    {
        exitButton.SetActive(false);
        notific.SetActive(false);
    }

    void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    void Update()
    {
        if (CheckWinCondition())
        {
            Time.timeScale = 0;
            notific.SetActive(true);
            exitButton.SetActive(true);
            Debug.Log("Chúc mừng! Bạn đã hoàn thành màn chơi!");
        }
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

}

