using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController1 : MonoBehaviour
{
    [SerializeField] private int runMultiplier;
    [SerializeField] private float footstepQuota;
    [SerializeField] private float stamina;


    private Rigidbody _rb;
    private Vector3 _currentMomentum;
 //   private Image _vignette;

    private AudioSource _audioSource;
    private bool _isInvokingStaminaRegen;


    private void Start()
    {
        footstepQuota = 50;
        _audioSource = gameObject.GetComponent<AudioSource>();
        runMultiplier = 1;
        _rb = gameObject.GetComponent<Rigidbody>();
  //      _vignette = GameObject.Find("Vignette").GetComponent<Image>();
    }

    private void RegenerateStamina()
    {
        if (runMultiplier != 1) return;
        stamina += 1;
        if (stamina < 100)
        {
            Invoke(nameof(RegenerateStamina), 0.1f);
            _isInvokingStaminaRegen = true;
        }
        else
        {
            stamina = 100;
            _isInvokingStaminaRegen = false;
        }
    }

    private void FixedUpdate()
    {
        if (footstepQuota <= 0)
        {
            footstepQuota = 50;
            _audioSource.Play();
        }


    //    _vignette.color = new Color(255, 255, 255, 50f / 50 - stamina / 50);

        if (runMultiplier == 1)
        {
            if (!_isInvokingStaminaRegen)
            {
                Invoke(nameof(RegenerateStamina), 1);
                _isInvokingStaminaRegen = true;
            }
        }

        if (Input.GetButton("Sprint"))
        {
            if (_currentMomentum != new Vector3(0, 0, 0) && Math.Abs(Input.GetAxis("Vertical") - 1) < 0.025)
            {
                if (stamina > 0)
                {
                    CancelInvoke(nameof(RegenerateStamina));
                    _isInvokingStaminaRegen = false;
                    runMultiplier = 2;
                    stamina -= 0.5f;
                }
                else
                {
                    runMultiplier = 1;
                    _isInvokingStaminaRegen = true;
                    Invoke(nameof(RegenerateStamina), 3);
                }
            }
            else
            {
                runMultiplier = 1;
            }
        }
        else
        {
            runMultiplier = 1;
        }


        _currentMomentum.z = Input.GetAxis("Vertical") * 3 * runMultiplier;
        _currentMomentum.x = Input.GetAxis("Horizontal") * 3 * runMultiplier;

        _rb.velocity = Input.GetAxis("Vertical") * 1.5f * runMultiplier * transform.forward +
                       Input.GetAxis("Horizontal") * 1.5f * runMultiplier * transform.right;
    }
}