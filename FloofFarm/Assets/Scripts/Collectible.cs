using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.itemsHeld.Add(this);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
