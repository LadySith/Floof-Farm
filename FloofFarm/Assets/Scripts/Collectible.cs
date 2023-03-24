using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;

    public Tile sproutTile;
    public Tile seedlingTile;
    public Tile plantTile;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player && player.itemsHeld.Count < player.maxItems)
        {
            player.itemsHeld.Add(this);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void growPlant(Vector3Int position)
    {
        GameManager.instance.tileManager.interactableMap.SetTile(position, sproutTile);
        StartCoroutine(plantGrowing(position));
    }

    IEnumerator plantGrowing(Vector3Int position)
    {
        yield return new WaitForSeconds(10f);
        GameManager.instance.tileManager.interactableMap.SetTile(position, seedlingTile);
        yield return new WaitForSeconds(10f);
        GameManager.instance.tileManager.interactableMap.SetTile(position, plantTile);
    }
}

public enum CollectibleType
{
    NONE, MUSHROOM, SEED
}
