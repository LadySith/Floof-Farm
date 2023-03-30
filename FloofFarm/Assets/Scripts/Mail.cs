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
        if (image == null)
        {
            rend.enabled = false;
        }
        else
        {
            rend.sprite = image;
            rend.enabled = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
