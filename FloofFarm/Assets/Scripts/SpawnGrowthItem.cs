using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrowthItem : MonoBehaviour
{
    public GameObject item;

    public float spawnInterval = 15.0f;

    float timeSinceSpawn = 0.0f;
    int randomPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= spawnInterval){
            GameObject growthItem = Instantiate(item) as GameObject;
            growthItem.transform.SetParent(GameObject.Find("Forest").transform, false);

            randomPosition = Random.Range(0, transform.childCount);

            for (int i = 0; i < transform.childCount; i++){
                if (i == randomPosition){
                    growthItem.transform.position = transform.GetChild(i).gameObject.transform.position;
                }
            }

            spawnInterval = Random.Range(10.0f, 30.0f);
            timeSinceSpawn = 0.0f;
        }
    }
}
