using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    private Light light;
    
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        StartCoroutine(ToggleLight(Random.Range(0,2), Random.Range(0,3)));
        }

    // Update is called once per frame. FixedUpdate is not.
    void FixedUpdate()
    {
    }
    IEnumerator ToggleLight(float delay, float waitTime){
        light.enabled = !light.enabled;
        yield return new WaitForSeconds(0.2f);
        if(light.enabled){
        yield return new WaitForSeconds(waitTime * 2);
        }else{
            yield return new WaitForSeconds(waitTime);
            }
    StartCoroutine(ToggleLight(Random.Range(0,2), Random.Range(0,3)));
    }
}
