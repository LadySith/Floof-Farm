using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    //[SerializeField] private Tile interactedTile;
    public List<Vector3Int> plantedTiles = new List<Vector3Int>();

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

    public void addPlantedTile(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null && tile.name == "Interactable" && !plantedTiles.Contains(position))
        {
            plantedTiles.Add(position);
        }
    }

    public bool isPlantedTile(Vector3Int position)
    {
        return plantedTiles.Contains(position);
    }

    public void removePlantedTile(Vector3 position)
    {
        Vector3Int posInt = GameManager.instance.tileManager.interactableMap.WorldToCell(position);

        if (plantedTiles.Contains(posInt))
        {
            plantedTiles.Remove(posInt);
        }
    }
}
