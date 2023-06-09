using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public FloofType floofType;
    public int growthStage;

    public SoundHandler sh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        sh = player.GetComponent<SoundHandler>();

        if (player && player.itemsHeld.Count < player.maxItems && type != CollectibleType.FLOOF)
        {
            player.itemsHeld.Add(this);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;

            if (type == CollectibleType.SEED)
            {
                type = CollectibleType.FLOOF;
                sh.PlayStep();
            }

            if (type == CollectibleType.DEWDROP)
            {
                sh.PlayDewDrop2();
            }

        }
    }

    public virtual void growPlant(Vector3Int position) { }

}

public enum CollectibleType
{
    NONE, DEWDROP, SEED, FLOOF
}

public enum FloofType
{
    NONE, BUNNYTAIL, CATSPJS, FOXTAIL
}
