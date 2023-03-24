using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float actionRadius;
    public int selectedItem;
    public int maxItems;
    public List<Collectible> itemsHeld = new List<Collectible>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos = new Vector3(pos.x, pos.y, 0);
            Vector3Int mousePosition = GameManager.instance.tileManager.interactableMap.WorldToCell(pos);
            Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            if (GameManager.instance.tileManager.IsInteractable(mousePosition) && (mousePos - playerPosition).magnitude < actionRadius)
            {
                plantMushroom(mousePosition);
            }
        }
    }

    private void plantMushroom(Vector3Int position)
    {
        if (selectedItem < itemsHeld.Count)
        {
            if (itemsHeld[selectedItem] != null)
            {
                GameManager.instance.tileManager.SetInteracted(position);
                GameManager.instance.tileManager.growPlant(position);
                itemsHeld.RemoveAt(selectedItem);
            }
        }
    }
}
