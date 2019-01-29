using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text pickup;
    public GameObject item;
    public GameObject itemA;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickup.gameObject.SetActive(true);
        }
        else
        {
            pickup.gameObject.SetActive(false);
        }
       
        if(Input.GetButton("Interact"))
        {
            Destroy(item);

            itemA.gameObject.SetActive(true);
        }
    }
}


   