using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mail : MonoBehaviour
{
    public Sprite image;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<SpriteRenderer>();
        rend.sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
