using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignetteScaleScript : MonoBehaviour
{
    [SerializeField]
    private int divideBy;
    [SerializeField]
    int fontSizeMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / divideBy,Screen.height);
       if(gameObject.GetComponent<Text>() != null){
           gameObject.GetComponent<Text>().fontSize = Screen.height / 30 * fontSizeMultiplier;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
