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
        //Permanently destroys the images in the scene. Using this as a quick workaround for it to stop activating to give room to other postcards.
        else if (fox.enabled == true)
        {
            Destroy(fox);
        }

        else if (cat.enabled == true)
        {
            Destroy(cat);
        }

        else if (bunny.enabled == true)
        {
            Destroy(bunny);
        }


    }


}
