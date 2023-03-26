using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float actionRadius;
    public int selectedItem;
    public int maxItems;
    public List<Collectible> itemsHeld = new List<Collectible>();
    public bool canReach;

    private void Update()
    {

        
    }

}
