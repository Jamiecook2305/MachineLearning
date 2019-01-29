using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprinting : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;
    public Slider StaminaBar;
    public float maxStamina;
    public float Staminalost;
    public float StaminaGain;
    public float sprintspeed = 5f;
    public float nosprintspeed = 1f;
    public float crouchspeed = 3.0f;
    

    // Use this for initialization
    void Start ()
    {
        CharacterController controller = GetComponent<CharacterController>();
	}

	void Update ()
    {

        {
            if (Input.GetButton("Sprint"))
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


                moveDirection *= sprintspeed;
                


                maxStamina -= Staminalost * Time.deltaTime;
                StaminaBar.value = maxStamina;

                if (maxStamina <= 0) //When the Stamina bar reaches 0
                {


                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                    maxStamina = 0;
                    moveDirection *= nosprintspeed;
                    


                    maxStamina += StaminaGain * Time.deltaTime;

                }


                if (Input.GetButton("Crouch"))
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);

                    moveDirection *= crouchspeed;
                    
                }
            }
        }
    }

}

