using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public float Smooth = 250.0f;
    public float speed = 15.0f;
    protected bool isCollect = false;
    protected GameObject Player;
    protected Vector2 Vec;
    protected float CurrentSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.active==true && isCollect==true)
        {
            Vec = Player.transform.position - transform.position;
            //Quaternion Rotation = Quaternion.LookRotation(Vector3.forward, Vec);
           // transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, Smooth * Time.deltaTime);
            transform.Translate(Vec * CurrentSpeed * Time.deltaTime);
        }    
    }
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            isCollect = false;
            Player.GetComponent<UserControll>().PlaysoundCoin();
            this.gameObject.SetActive(false);
            GameObject Canvas = GameObject.FindGameObjectWithTag("CanVas");
            Canvas.GetComponent<Canvas>().AddGold();
        }
    }
    public void GoToPlayer()
    {
        isCollect = true;
    }
}
