using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Puzzle1Script : MonoBehaviour
{
    [SerializeField]
    Material mat1;
    [SerializeField]
    Material mat2;
    [SerializeField]
    Material mat3;
    [SerializeField]
    int winMaterial;
    [SerializeField]
    Puzzle1Controller controller;
    bool haveWon;
    Renderer rend;
    Dictionary<int, Material> materials;
    [SerializeField]
    private int currentMaterial;
    // Start is called before the first frame update
    void Start()
    {
       
        controller = GameObject.Find("Puzzle1ControllerCube").GetComponent<Puzzle1Controller>();
        materials = new Dictionary<int, Material>();
        materials[1] = mat1;
        materials[2] = mat2;
        materials[3] = mat3;
        currentMaterial = 1;
        rend = gameObject.GetComponent<Renderer>();
         if(currentMaterial == winMaterial){
               controller.winValue += 1;
               haveWon = true;
        }
        
    }

    // Update is called once per frame. Fixed Update is not.
    void FixedUpdate()
    {
        rend.material = materials[currentMaterial];
    }
     void OnMouseOver(){
    if(Input.GetMouseButtonDown(0)){
       if(currentMaterial < materials.Count){
           currentMaterial += 1;
           if(currentMaterial == winMaterial){
               controller.winValue += 1;
               haveWon = true;
           }else if(haveWon){
               haveWon = false;
               controller.winValue -= 1;
           }
       }else{
           currentMaterial = 1;
       }
    }
}
}