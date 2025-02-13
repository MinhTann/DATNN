using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Gird : MonoBehaviour
{
   public Transform[,] gird;
   public int width , height;
    void Start()
    {
        gird = new Transform[width , height];
    }

public void UpdateGird(Transform tetromino){
    for (int y =0; y < height; y++){
        for(int x =0; x < width; x++){
            if(gird[x,y] !=null){
                if(gird[x,y].parent == tetromino){
                    gird[x,y] = null;
                }
            }
        }
    }
    foreach(Transform mino in tetromino){
        Vector2 pos = Round(mino.position);
        if(pos.y <height){
            gird[(int)pos.x, (int)pos.y] = mino;
        }
    }
}

public static Vector2 Round(Vector2 v){
    return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));
}

    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInsideBorder(Vector2 pos){
        return (int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0 && (int)pos.y < height;
    }

    public Transform GetTranformAtGirdPosition(Vector2 pos){
        if(pos.y > height - 1){
            return null;
        }
        return gird[(int)pos.x , (int)pos.y ];
    }
    public bool IsValidPosition(Transform tetromino){
        foreach(Transform mino in tetromino){

            Vector2 pos = Round(mino.position);
            if(IsInsideBorder(pos)){
                return false;
            }
            if(GetTranformAtGirdPosition(pos) != null && GetTranformAtGirdPosition(pos).parent != tetromino){
                return false;
            }  
         }
            return true;    
        }
        public void CheckForLines(){
            for(int y= 0; y < height; y++){
                if(LineIsFull(y)){
                    DeleteLine(y);
                    DecreaseRowsAbove(y+1);
                    y--;
                }
            }
        }
        bool LineIsFull(int y){
            for (int x= 0; x < width; x++){
                if (gird[x, y] == null){
                    return false;
                }
            }
            return true;
        }
        void DeleteLine(int y){
            for(int x = 0; x < width; x++){
                Destroy(gird[x,y].gameObject);
                gird[x, y] = null;
            }
        }
        void DecreaseRowsAbove(int starRow){
            for (int y = starRow; y < height ; y++){
                for(int x =0 ; x < width ; x++){

                    if(gird[x, y] != null){
                    
                        gird[x, y - 1] = gird[x,y];
                        gird[x ,y] = null;
                        gird[x, y - 1].position += Vector3.down;

                    }
                }
            }
        }
    }

