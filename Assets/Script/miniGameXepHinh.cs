using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGameXepHinh : MonoBehaviour
{
    public GameObject[] Tetrominos;

    public float movementFrequency = 0.8f;
    private float passedTime = 0;
    private GameObject currentTetromino , nextTetromino;
    public int currentTetrominoIndex , nextTetrominoIndex ;
    public bool isRotating = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime >= movementFrequency)
        {
            passedTime -= movementFrequency;
            MoveTetromino(Vector3.down);
        }
        UserInput();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTetromino(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTetromino(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentTetromino.transform.Rotate(0, 0, 90);
            if (!IsValidPosition())
            {
                currentTetromino.transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementFrequency = 0.1f;
        }
        else
        {
            movementFrequency = 0.8f;
        }
    }

    void SpawnTetromino()
    {
        int[] index = {
            Random.Range(0 , Tetrominos.Length - 1),
            Random.Range(0 , Tetrominos.Length - 1),
            Random.Range(0 , Tetrominos.Length - 1)

        };
        if (nextTetromino == null){
            currentTetromino = Instantiate(Tetrominos[index[0]], new Vector3(5 , 19 ,0), Quaternion.identity);
            currentTetrominoIndex = index[0];
            nextTetromino = Instantiate(Tetrominos[index[1]], new Vector3(16 , 13 ,0) , Quaternion.identity);
            nextTetrominoIndex = index[1];
        }
        else{
            currentTetromino = nextTetromino;
            currentTetromino.transform.position = new Vector3(5 , 16, 0);
            currentTetrominoIndex = nextTetrominoIndex;
            nextTetromino = Instantiate(Tetrominos[index[2]] , new Vector3(16 , 13 ,0), Quaternion.identity);
            nextTetrominoIndex = index[2];

      
        }
    }

    void MoveTetromino(Vector3 direction)
    {
        currentTetromino.transform.position += direction;
        if (!IsValidPosition())
        {
            currentTetromino.transform.position -= direction;
            if (direction == Vector3.down)
            {
                GetComponent<Gird>().UpdateGird(currentTetromino.transform);
                CheckForLines();
                SpawnTetromino();
            }
        }
    }

    bool IsValidPosition()
    {
        return GetComponent<Gird>().IsValidPosition(currentTetromino.transform);
    }

    void CheckForLines()
    {
        GetComponent<Gird>().CheckForLines();
    }
}
