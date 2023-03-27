using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrowthItem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public float spawnInterval = 15.0f;
    public float intervalMin = 10.0f;
    public float intervalMax = 30.0f;

    float timeSinceSpawn = 0.0f;
    int randomPosition;
    int randomItem;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= spawnInterval){
            randomItem = Random.Range(0, items.Count);

            GameObject growthItem = Instantiate(items[randomItem]) as GameObject;
            growthItem.transform.SetParent(GameObject.Find("Forest").transform, false);

            randomPosition = Random.Range(0, transform.childCount);

            for (int i = 0; i < transform.childCount; i++){
                if (i == randomPosition){
                    growthItem.transform.position = transform.GetChild(i).gameObject.transform.position;
                }
            }

            spawnInterval = Random.Range(intervalMin, intervalMax);
            timeSinceSpawn = 0.0f;
        }
    }
}
