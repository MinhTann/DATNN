using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform cardField;

    [SerializeField]
    private GameObject button;
    
    private void Awake(){
        for(int i = 0; i <8; i++){
            GameObject _button = Instantiate(button);
            _button.name = "" + i;
            _button.transform.SetParent(cardField, false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
