using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GridScript : MonoBehaviour
{
    public Transform[,] grid;
    private static int score;
    public GameObject winText;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI monsterListText;
    
    private List<string> collectedMonsters = new List<string>(); 
    public List<string> monsterPool = new List<string> { "Chuot", "Doi" };
    public int width, height;


    public Image golemImage;
    public Image doiImage;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Transform[width, height];
        score = 0;
        winText.SetActive(false);

        golemImage.gameObject.SetActive(false);
        doiImage.gameObject.SetActive(false);


        UpdateMonsterUI();
        
    }
    void Update()
    {

    }

    public void UpdateGrid(Transform tetromino)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == tetromino)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform mino in tetromino)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < height)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
        if (IsTopRowOccupied())
        {
            SceneManager.LoadScene(5);
        }
    }

    public static Vector2 Round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    // Update is called once per frame

    public bool IsInsideBorder(Vector2 pos)
    {
        return (int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0 && (int)pos.y < height;
    }

    public Transform GetTransformAtGridPosition(Vector2 pos)
    {
        if (pos.y > height - 1)
        {
            return null;
        }
        return grid[(int)pos.x, (int)pos.y];
    }

    public bool IsValidPosition(Transform tetromino)
    {
        foreach (Transform mino in tetromino)
        {
            Vector2 pos = Round(mino.position);
            if (!IsInsideBorder(pos))
            {
                return false;
            }

            if (GetTransformAtGridPosition(pos) != null && GetTransformAtGridPosition(pos).parent != tetromino)
            {
                return false;
            }
        }
        return true;
    }

    public void CheckForLines()
    {
        int LineCounts = 0;
        for (int y = 0; y < height; y++)
        {
            if (LineIsFull(y))
            {
                DeleteLine(y);
                CollectMonster();
                DecreaseRowsAbove(y + 1);
                y--;
                LineCounts++;
            }
        }
        if (LineCounts > 0)
        {
            switch (LineCounts)
            {
                case 1: score += 10; break;
                case 2: score += 15; break;
                case 3: score += 20; break;
                case 4: score += 30; break;
                default: break;

            }

            scoretext.text = "Score: " + score.ToString();

            if (score == 30)
            {
                //winText.SetActive(true);
                LoadScene1();
                Time.timeScale = 0;
                Debug.Log("YOU WIN!");
            }
        }




    }
    private bool IsTopRowOccupied()
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, height - 1] != null)
            {
                return true;
            }
        }
        return false;
    }

    bool LineIsFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    void DecreaseRowsAbove(int startRow)
    {
        for (int y = startRow; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }

    private void CollectMonster()
    {
        if (monsterPool.Count > 0)
        {
            int randomIndex = Random.Range(0, monsterPool.Count);
            string collectedMonster = monsterPool[randomIndex];

            if (!collectedMonsters.Contains(collectedMonster)) // Tránh thu thập trùng quái vật
            {
                collectedMonsters.Add(collectedMonster);
                Debug.Log("Bạn đã thu thập quái vật: " + collectedMonster);
                UpdateMonsterUI(); // Cập nhật UI
            }

        }
    }
        private void UpdateMonsterUI()
    {
        if (monsterListText != null)
        {
            monsterListText.text = "Quái vật: " + string.Join(", ", collectedMonsters);
        }

       foreach (string monster in collectedMonsters)
        {
            if (monster == "Golem") golemImage.gameObject.SetActive(true);
            if (monster == "Doi") doiImage.gameObject.SetActive(true);
        }
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("GameOver");
    }


}
