using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingScripts : MonoBehaviour
{

    public Text pressE;
    public GameObject Player;
    public Camera CloCam;
    public Camera Maincamera;
    

    private void Start()
    {
        Maincamera.gameObject.SetActive(true); //On start of the game will automatically able/disable these cameras 
        CloCam.gameObject.SetActive(false);
    }

    //Ontrigger means it "triggers" when any GameObject with a collider enters it's collider in this case only GameObjects with the Player Tag will activate its trigger.
    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.gameObject.CompareTag("Player"))
            {
                pressE.gameObject.SetActive(true);
            }
            else //else means Opposite in this case this would be if player goes outside the collider range 
            {
                pressE.gameObject.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Interact")) //Interact is a custom input button is E go to Edit > Project settings > Input 
        {
            Player.gameObject.SetActive(false);
            Maincamera.gameObject.SetActive(false); //Player will disappear and the closet camera will activate 
            CloCam.gameObject.SetActive(true);
        }
        
    }
       private void Update()
       {
        {
            if (Input.GetButtonDown("Interact2"))
            {
                Player.gameObject.SetActive(true);
                Maincamera.gameObject.SetActive(true); //Player will reappear and closet camera will deactivate 
                CloCam.gameObject.SetActive(false);
            }
        

       }
    }
}
  
  