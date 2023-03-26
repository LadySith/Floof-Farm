using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public Player player;
    public SpriteRenderer mail;


    bool deliveredBunny = false;
    bool deliveredCat = false;
    bool deliveredFox = false;

    // Update is called once per frame
    void OnMouseDown()
    {

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Bunny With CottonBall!");
            player.itemsHeld.RemoveAt(player.selectedItem);
            deliveredBunny = true;
            StartCoroutine(postCardDelivery());
        }

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Cat In PJs!");
            player.itemsHeld.RemoveAt(player.selectedItem);
            deliveredCat = true;
            StartCoroutine(postCardDelivery());
        }

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Fox With Fluffy Tail!");
            player.itemsHeld.RemoveAt(player.selectedItem);
            deliveredFox = true;
            StartCoroutine(postCardDelivery());
        }


    }


    IEnumerator postCardDelivery()
    {
        if (deliveredBunny == true || deliveredCat == true || deliveredFox == true)
        {
            yield return new WaitForSeconds(5f);
            mail.enabled = true;
            print("Postcard!");
        }

        else
        {
            mail.enabled = false;
        }
    }

    
}
