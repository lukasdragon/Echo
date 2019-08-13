using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController1 : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 currentMomentum;
    [SerializeField]
    int runMultiplier;
    Image vignette;
    [SerializeField]
    float stamina;
    AudioSource audioSource;
    bool isInvokingStaminaRegen;
    [SerializeField]
    float footstepQuota;
    Vector3 rigidbodyClone;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyClone = new Vector3();
        footstepQuota = 50;
        audioSource = gameObject.GetComponent<AudioSource>();
        runMultiplier = 1;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        vignette = GameObject.Find("Vignette").GetComponent<Image>();
    }
    void RegenerateStamina(){
        if(runMultiplier == 1){
        stamina += 1;
        if(stamina < 100){
            Invoke("RegenerateStamina",0.1f);
            isInvokingStaminaRegen = true;
        }else{
            stamina = 100;
            isInvokingStaminaRegen = false;
        }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        rigidbodyClone = rigidbody.velocity;
        if(footstepQuota <= 0){
            footstepQuota = 50;
        audioSource.Play();
        }
        /* if(rigidbodyClone.z => 0 ){
            if(rigidbodyClone.x >= 0){
                if(rigidbodyClone.z => rigidbodyClone.x){
                    footstepQuota -= rigidbodyClone.z;
                }else{
                    footstepQuota -= rigidbodyClone.x;
                }                        
            }else{
              if(rigidbodyClone.z >= rigidbodyClone.x * -1){  
                  footstepQuota -= rigidbodyClone.z;
            }else{
                footstepQuota -= rigidbodyClone.x * -1;
            }
            }
        }else{
            if(rigidbodyClone.x >= 0 ){
         if(rigidbodyClone.z * -1 >= rigidbodyClone.x){ 
             footstepQuota -= rigidbodyClone.z * -1;
        }else{
            footstepQuota -= rigidbodyClone.x;
        }
            }else{
                 if(rigidbodyClone.z >= rigidbodyClone.x){
                   footstepQuota -= rigidbodyClone.x * -1;  
            }else{
                footstepQuota -= rigidbodyClone.z * -1;
            }
            }
        }
    */
        vignette.color = new Color(255,255,255,50 / 50 - stamina / 50);
        
        if(runMultiplier == 1){           
            if(!isInvokingStaminaRegen){
            Invoke("RegenerateStamina",1);
            isInvokingStaminaRegen = true;
        }
        } if(Input.GetButton("Sprint")){
            if(currentMomentum != new Vector3(0,0,0) && Input.GetAxis("Vertical") == 1){
                if(stamina > 0){
                CancelInvoke("RegenerateStamina");
                isInvokingStaminaRegen = false;
                runMultiplier = 2;
                stamina -= 0.5f;
            }else{
                runMultiplier = 1;
                isInvokingStaminaRegen = true;
                Invoke("RegenerateStamina", 3);
            }
            
            }else{
            runMultiplier = 1;
            }
          //  if(isInvokingStaminaRegen){
            
      //  }
        }else{
            runMultiplier = 1;
        }
    
         
                currentMomentum.z = Input.GetAxis("Vertical") * 3 * runMultiplier;
                currentMomentum.x = Input.GetAxis("Horizontal") * 3 * runMultiplier;
    
        //rigidbody.velocity = gameObject.transform.InverseTransformDirection(currentMomentum);
        rigidbody.velocity = transform.forward * Input.GetAxis("Vertical") * 1.5f * runMultiplier + transform.right * Input.GetAxis("Horizontal") * 1.5f * runMultiplier;
    }
}
