using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Main : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBr;
    public Transform sideBr;
    public float lenght;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > midBr.position.x)
        {
            UpdateBaclGroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < midBr.position.x)
        {
            UpdateBaclGroundPosition(Vector3.left);
        }
        midBr.position = new Vector3(midBr.position.x, mainCam.position.y, midBr.position.z);
        //sideBr.position = new Vector3(sideBr.position.x, mainCam.position.y, sideBr.position.z);


    }
    void UpdateBaclGroundPosition(Vector3 dirention)
    {

        sideBr.position = midBr.position + dirention * lenght;
        Transform temp = midBr;
        midBr = sideBr;
        sideBr = temp;
    }
}
