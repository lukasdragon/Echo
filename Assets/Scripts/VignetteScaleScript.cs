using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignetteScaleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
