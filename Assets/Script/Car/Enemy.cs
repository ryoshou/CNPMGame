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
        if (Player.active == false)
            return;
        Vec = Player.transform.position - transform.position;
        Corner = Vector2.Angle(new Vector2(transform.up.x,transform.up.y), Vec);
        Quaternion Rotation = Quaternion.LookRotation(Vector3.forward, Vec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, Smooth * Time.deltaTime);
        transform.Translate(Vector2.up * CurrentSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Enemy")
        {
            //col2.gameObject.SetActive(false);
            Player.GetComponent<UserControll>().PlaysoundEnemydie();
           this.gameObject.SetActive(false);
           GameObject Explode =  ObjectPooler.Instance.SpawnFromPool("explode", this.transform.position, this.transform.rotation);
           Explode.GetComponent<explode>().Hit();
        }
        if (col2.gameObject.tag == "Player")
        {
            col2.gameObject.GetComponent<UserControll>().PlayerDie();
            GameObject Explode = ObjectPooler.Instance.SpawnFromPool("explode", col2.transform.position, col2.transform.rotation);
            Explode.GetComponent<explode>().Hit();
        }
    }
}
