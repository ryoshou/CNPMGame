using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
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
        if (col2.gameObject.tag == "Player" && this.gameObject.active == true)
        {
            col2.GetComponent<UserControll>().openMagnet();
            this.gameObject.SetActive(false);
        }
    }
}
