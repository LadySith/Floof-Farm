using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player && player.itemsHeld.Count < player.maxItems && type != CollectibleType.FLOOF)
        {
            player.itemsHeld.Add(this);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;

            if (type == CollectibleType.SEED)
            {
                type = CollectibleType.FLOOF;
            }
        }
    }

    public virtual void growPlant(Vector3Int position) { }

}

public enum CollectibleType
{
    NONE, DEWDROP, SEED, FLOOF
}
