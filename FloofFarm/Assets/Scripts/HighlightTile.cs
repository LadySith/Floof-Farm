using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTile : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Tilemap hoverMap;
    [SerializeField] private Tile hoverTile;
    [SerializeField] private Tile hoverTileTP;

    private Vector3Int previousMousePosition = new Vector3Int();
    private Tile tileToSet;
    private Tile otherTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int mousePositionInt = GameManager.instance.mousePosInt;

        if (player.canReach)
        {
            tileToSet = hoverTile;
            otherTile = hoverTileTP;

        }
        else
        {
            tileToSet = hoverTileTP;
            otherTile = hoverTile;
        }

        if (hoverMap.GetTile(mousePositionInt) != null && hoverMap.GetTile(mousePositionInt).name == otherTile.name)
        {
            hoverMap.SetTile(mousePositionInt, tileToSet);
        }

        if (!Equals(mousePositionInt, previousMousePosition))
        {
            hoverMap.SetTile(previousMousePosition, null);
            hoverMap.SetTile(mousePositionInt, tileToSet);
            previousMousePosition = mousePositionInt;
        }
    }
}
