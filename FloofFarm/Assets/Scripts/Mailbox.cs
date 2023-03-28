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

    // Update is called once per frame
    void OnMouseDown()
    {
        if (player.canReach && player.itemsHeld.Count > 0 && player.selectedItem < player.itemsHeld.Count)
        {
            if (player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL)
            {
                print("Delivered Bunny With CottonBall!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredBunny = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS)
            {
                print("Delivered Cat In PJs!");
                player.itemsHeld.RemoveAt(player.selectedItem);
                deliveredCat = true;
                StartCoroutine(postCardDelivery());
            }

            else if (player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL)
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
            print("Postcard!");
        }

        else
        {
            mail.SetActive(false);
        }
    }

    
}
