using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostCard : MonoBehaviour
{
    public Player player;
    public Mailbox mailbox;

    public Image bunny;
    public Image cat;
    public Image fox;

    void OnMouseDown()
    {

        //Shows Postcard on click
        if (player.canReach && mailbox.deliveredBunny)
        {
            bunny.enabled = true;
            
        }

        else if (player.canReach && mailbox.deliveredCat)
        {
                cat.enabled = true;
        }


        else if (player.canReach && mailbox.deliveredFox)
        {
            fox.enabled = true;
        }


        //Hides Postcard on click (only works if you click the on mailbox collider for now
        else if (fox.enabled == true)
        {
            fox.enabled = false;
        }

        else if (cat.enabled == true)
        {
            cat.enabled = false;
        }

        else if (bunny.enabled == true)
        {
            bunny.enabled = false;
        }

    }


}
