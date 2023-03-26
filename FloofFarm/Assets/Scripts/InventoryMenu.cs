using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{

    public Player player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.maxItems; i++){

            GameObject child = gameObject.transform.GetChild(i).gameObject;

            if (i < player.itemsHeld.Count)
            {
                if (player.itemsHeld[i] != null)
                {
                    GameObject inventoryItem = player.itemsHeld[i].transform.GetChild(0).gameObject;
                    child.GetComponent<Image>().sprite = inventoryItem.GetComponent<SpriteRenderer>().sprite;
                    child.SetActive(true);
                }
            }

            else
            {
                child.SetActive(false);
            }
        }
    }

    public void SelectItem(int index){
        player.selectedItem = index;
    }
}
