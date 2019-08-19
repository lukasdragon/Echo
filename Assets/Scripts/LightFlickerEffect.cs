using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Light))]
public class LightFlickerEffect : MonoBehaviour
{

    [SerializeField] private float minTime = 0.05f;
    [SerializeField] private float maxTime = 1.2f;

    private float _timer;
    private Light _light;

    private void Start()
    {
        _light = gameObject.GetComponent<Light>();
        _timer = Random.Range(minTime, maxTime);
    }


    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _light.enabled = !_light.enabled;
            _timer = Random.Range(minTime, maxTime);
        }
    }

}
