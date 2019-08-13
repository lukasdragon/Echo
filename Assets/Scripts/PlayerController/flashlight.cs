using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    [SerializeField] private Light fLight;


    private void Update()
    {
        if (Input.GetButtonDown("flashlight"))
            fLight.enabled = !fLight.enabled;
    }
}