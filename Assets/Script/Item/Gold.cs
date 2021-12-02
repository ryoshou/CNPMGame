using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col2)
    {
        Debug.Log("aaa");
        if (col2.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            GameObject Canvas = GameObject.FindGameObjectWithTag("CanVas");
            Canvas.GetComponent<Canvas>().AddGold();
        }
    }
}
