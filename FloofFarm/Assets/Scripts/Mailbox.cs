using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public Player player;
    public GameObject mail;
    public GameObject floof;


    public bool deliveredBunny = false;
    public bool deliveredCat = false;
    public bool deliveredFox = false;

    private SoundHandler sh;

    private void Start()
    {
        sh = player.GetComponent<SoundHandler>();

    }



    // Update is called once per frame
    void OnMouseDown()
    {
        

        if (player.canReach && player.itemsHeld.Count > 0 && player.selectedItem < player.itemsHeld.Count)
        {
            if (player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Bunny With CottonBall!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredBunny = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Cat In PJs!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredCat = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL && player.itemsHeld[player.selectedItem].growthStage == 3)
            {
                print("Delivered Fox With Fluffy Tail!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredFox = true;
                StartCoroutine(postCardDelivery());
            }
        }
    }


    IEnumerator postCardDelivery()
    {
        if (deliveredBunny == true || deliveredCat == true || deliveredFox == true)
        {
            yield return new WaitForSeconds(5f);
            mail.SetActive(true);
            sh.PlayBell();
            print("Postcard!");
        }

        else
        {
            mail.SetActive(false);
        }
    }

    
}
