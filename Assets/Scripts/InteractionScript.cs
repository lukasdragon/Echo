using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
private NoteScript noteScript;
private GameObject player;
//private XXX xxx;
private void Start(){
player = GameObject.Find("CameraController");
noteScript = gameObject.GetComponent<NoteScript>();
if(noteScript == null){
    Debug.Log("No NoteScript has been found");
}else{
    Debug.Log(noteScript);
}
//noteScript.enabled = true;
if(noteScript == null){
//xxx = gameObject.GetComponent<XXX>();
//if(xxx = null){
//}
}
}

private void OnMouseOver(){
if(Input.GetButtonDown("Interact")){
if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 3){
noteScript.enabled = true;
//xxx.enabled = true;
this.enabled = false;
}
}
}
}
