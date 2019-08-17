using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteScript : MonoBehaviour
{
//NoteScript
private GameObject noteGui;
private AudioSource audioSource;
[SerializeField]
private string noteText;

private void Start(){
noteGui = GameObject.Find("NoteGui");
audioSource = gameObject.GetComponent<AudioSource>();
GameObject.Find("NoteTextGui").GetComponent<UnityEngine.UI.Text>().enabled = true;
GameObject.Find("NoteTextGui").GetComponent<UnityEngine.UI.Text>().text = noteText;
noteGui.GetComponent<Image>().enabled = true;
audioSource.Play();
}

private void FixedUpdate(){


if(Input.GetButtonDown("Interact")){

GameObject.Find("NoteTextGui").GetComponent<UnityEngine.UI.Text>().enabled = false;
noteGui.GetComponent<Image>().enabled = false;
Destroy(gameObject);
}
}
}
