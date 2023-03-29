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
    public Vector3Int mousePosInt;

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
        mousePosInt = tileManager.interactableMap.WorldToCell(posInWorld);
        player.canReach = (mousePosition - player.transform.position).magnitude < player.actionRadius;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Selected item = " + player.selectedItem);

            if (tileManager.IsInteractable(mousePosInt) && player.canReach && player.selectedItem < player.itemsHeld.Count)
            {
                Collectible item = player.itemsHeld[player.selectedItem];

                if (item.type == CollectibleType.FLOOF && !tileManager.isPlantedTile(mousePosInt))
                {
                    item.growPlant(mousePosInt);
                    tileManager.addPlantedTile(mousePosInt);
                }
                
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
