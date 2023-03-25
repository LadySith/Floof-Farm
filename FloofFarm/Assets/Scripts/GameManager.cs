using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public TileManager tileManager;

    public Vector3 posInWorld;
    public Vector3 mousePosition;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        tileManager = GetComponent<TileManager>();
    }

    private void Update()
    {
        posInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(posInWorld.x, posInWorld.y, 0);
        Vector3Int mousePosInt = tileManager.interactableMap.WorldToCell(posInWorld);

        if (Input.GetMouseButtonDown(0))
        {
            if (tileManager.IsInteractable(mousePosInt) && (mousePosition - player.transform.position).magnitude < player.actionRadius && player.selectedItem < player.itemsHeld.Count)
            {
                Collectible item = player.itemsHeld[player.selectedItem];

                if (item.type == CollectibleType.FLOOF)
                {
                    item.growPlant(mousePosInt);
                }
                
            }
        }
    }

    
}
