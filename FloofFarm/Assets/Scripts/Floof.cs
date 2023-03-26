using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floof : Collectible
{
    
    public int growthStage;
    public Sprite[] growthSprites = new Sprite[4]; //For growthSprites[x], 0 = sprout, 1 = seedling, 2 = plant, 3 = floof
    private Player player;
    private bool growing;

    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        growthStage = 0;
        rend = GetComponentInChildren<SpriteRenderer>();
        rend.sprite = growthSprites[growthStage];
        player = GameManager.instance.player;
        growing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if ((GameManager.instance.mousePosition - player.transform.position).magnitude < player.actionRadius)
        {
            if (growthStage == 0)
            {
                if (player.itemsHeld.Count > 0 && player.itemsHeld[player.selectedItem] != null && player.itemsHeld[player.selectedItem].type == CollectibleType.DEWDROP && !growing)
                {
                    player.itemsHeld.RemoveAt(player.selectedItem);
                    StartCoroutine(growFloof());
                    growing = true;
                }
            }

            if (growthStage == 3 && player.itemsHeld.Count < 10)
            {
                harvestFloof();
            }
        }
    }

    public override void growPlant(Vector3Int position)
    {
        if (growthStage == 0)
        {
            Vector3 pos = GameManager.instance.tileManager.interactableMap.GetCellCenterLocal(position);
            Floof newFloof = Instantiate(this, pos, Quaternion.identity);
            newFloof.type = CollectibleType.FLOOF;
            player.itemsHeld.RemoveAt(player.selectedItem);
        }
    }

    IEnumerator growFloof()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(10f);
            growthStage++;
            rend.sprite = growthSprites[growthStage];
        }
    }

    private void harvestFloof()
    {
        GameManager.instance.tileManager.removePlantedTile(this.transform.position);
        growing = false;
        type = CollectibleType.FLOOF;
        player.itemsHeld.Add(this);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }
}


