using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrowthItem : MonoBehaviour
{
    public GameObject item;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(-10000, 10000) == 50){
            GameObject growthItem = Instantiate(item) as GameObject;
            growthItem.transform.SetParent(GameObject.Find("Forest").transform, false);
            growthItem.transform.position = new Vector2(Random.Range(-6, 6), Random.Range(-3, -1));
        }
    }
}
