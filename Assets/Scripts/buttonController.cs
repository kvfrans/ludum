using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer SR;
    public Sprite unclickImg;
    public Sprite clickImg;
    public KeyCode keyToHit;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SR.sprite = clickImg;

        }
        if (Input.GetMouseButtonUp(0))
        {
            SR.sprite = unclickImg;
        }
    }
    
}
