using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Text craft;
    public GameObject item;
    public GameObject InventoryUI;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            craft.gameObject.SetActive(true);
        }
        { 
            if (Input.GetButtonDown("Interact"))
            {
                
                }
                if (GameIsPaused)
                {

                    Resume();
                }
                else
                {
                    Pause();

                }
            }
        }

            public void Resume()
            {
                InventoryUI.SetActive(false);
               
                Time.timeScale = 1f;
                GameIsPaused = false;
            }

            void Pause()
            {
                InventoryUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }

  