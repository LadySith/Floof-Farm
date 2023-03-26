using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public Player player;


    // Update is called once per frame
    void OnMouseDown()
    {

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.BUNNYTAIL && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Bunny With CottonBall!");
            player.itemsHeld.RemoveAt(player.selectedItem);
        }

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.CATSPJS && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Cat In PJs!");
            player.itemsHeld.RemoveAt(player.selectedItem);
        }

        if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] && player.itemsHeld[player.selectedItem].floofType == FloofType.FOXTAIL && (GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            print("Delivered Fox With Fluffy Tail!");
            player.itemsHeld.RemoveAt(player.selectedItem);
        }


    }

        
    
}
