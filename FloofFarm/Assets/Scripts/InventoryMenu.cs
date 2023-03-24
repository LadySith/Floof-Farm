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
        for (int i = 0; i < player.itemsHeld.Count; i++){
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<Image>().sprite = player.itemsHeld[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            child.SetActive(true);
        }
    }
}
