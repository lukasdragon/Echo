using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    [SerializeField] private Light fLight;
    [SerializeField] private AudioSource aSource;


    private void Update()
    {
        if (Input.GetButtonDown("flashlight")){
        aSource.Play();
            fLight.enabled = !fLight.enabled;
    }
}
}