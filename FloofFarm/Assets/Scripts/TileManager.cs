using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;
    [SerializeField] private Tile sproutTile;
    [SerializeField] private Tile seedlingTile;
    [SerializeField] private Tile plantTile;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null && tile.name == "Interactable_Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null && tile.name == "Interactable")
        {
            return true;
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }

    public void growPlant(Vector3Int position)
    {
        StartCoroutine(plantGrowing(position));
    }

    IEnumerator plantGrowing(Vector3Int position)
    {
        yield return new WaitForSeconds(10f);
        interactableMap.SetTile(position, sproutTile);
        yield return new WaitForSeconds(10f);
        interactableMap.SetTile(position, seedlingTile);
        yield return new WaitForSeconds(10f);
        interactableMap.SetTile(position, plantTile);
    }
}
