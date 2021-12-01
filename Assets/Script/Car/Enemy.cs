using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 6.0f;
    public float Smooth = 250.0f;
    protected GameObject Player;
    protected Vector2 Vec;
    protected float CurrentSpeed = 0;
    float Corner = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;
        Vec = Player.transform.position - transform.position;
        Corner = Vector2.Angle(new Vector2(transform.up.x,transform.up.y), Vec);
        Quaternion Rotation = Quaternion.LookRotation(Vector3.forward, Vec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 250 * Time.deltaTime);
        transform.Translate(Vector2.up * CurrentSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Enemy")
        {
           col2.gameObject.SetActive(false);
           this.gameObject.SetActive(false);
        }
        if (col2.gameObject.tag == "Player")
        {
            col2.gameObject.SetActive(false);
        }
    }
}
