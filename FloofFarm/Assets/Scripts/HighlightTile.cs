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
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = new Vector3(pos.x, pos.y, 0);
        Vector3Int mousePosition = GameManager.instance.tileManager.interactableMap.WorldToCell(pos);
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if ((mousePos - playerPosition).magnitude < player.actionRadius)
        {
            tileToSet = hoverTile;
            otherTile = hoverTileTP;

        }
        else
        {
            tileToSet = hoverTileTP;
            otherTile = hoverTile;
        }

        if (hoverMap.GetTile(mousePosition) != null && hoverMap.GetTile(mousePosition).name == otherTile.name)
        {
            hoverMap.SetTile(mousePosition, tileToSet);
        }

        if (!Equals(mousePosition, previousMousePosition))
        {
            hoverMap.SetTile(previousMousePosition, null);
            hoverMap.SetTile(mousePosition, tileToSet);
            previousMousePosition = mousePosition;
        }
    }
}
