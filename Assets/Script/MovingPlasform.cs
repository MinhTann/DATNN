using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MovingPlasform : MonoBehaviour
{
    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 nextLocation;

    [SerializeField] private Transform plasform;
    [SerializeField] private Transform MovingToLocation;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        LocationA = plasform.localPosition;
        LocationB = MovingToLocation.localPosition;
        nextLocation = LocationB;
       

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move(){
        plasform.localPosition = Vector3.MoveTowards(plasform.localPosition, nextLocation, speed * Time.deltaTime);

        if (Vector3.Distance(plasform.localPosition, nextLocation) <= 0.1){
             ChangePosition();
        }
    }
    private void ChangePosition(){
        nextLocation = nextLocation != LocationA ? LocationA  : LocationB;
       
    }
}
