using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Controller : MonoBehaviour
{
    public int winValue;
    [SerializeField]
    int requiredWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. Fixed Update is not.
    void FixedUpdate()
    {
        if(winValue == requiredWin){
            gameObject.SetActive(false);
        }
    }
}
