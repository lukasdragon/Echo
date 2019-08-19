using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.collider.gameObject.name == "Player"){
            GameObject.Find("MiscMessageGui").GetComponent<UnityEngine.UI.Text>().text = "I cannot leave alone.";
            GameObject.Find("MiscMessageGui").GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
    }
    void OnCollisionExit(Collision collision){
        if(collision.collider.gameObject.name == "Player"){
            GameObject.Find("MiscMessageGui").GetComponent<UnityEngine.UI.Text>().text = "";
            GameObject.Find("MiscMessageGui").GetComponent<UnityEngine.UI.Text>().enabled = false;
        }
    }
}
