using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float DistanceHeight = 10.0f;
    public float DistanceWitdh = 15.0f;
    public float SafeWitdh = 15.0f;
    public float SafeHeight = 10.0f;
    public float TimeSpawn = 2.5f;
    public GameObject Player;
    public GameObject Enemy;
    protected Vector2 Vec;
    float posX = 0;
    float PosY = 0;
    int[] Arr = { -1, 1 };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(TimeSpawn));
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawn(float second)
    {
        yield return new WaitForSeconds(second);
        if (Player.active == true)
        {
            posX = Arr[Random.Range(0,1)]* Random.Range(SafeWitdh, DistanceWitdh);
            PosY = Arr[Random.Range(0, 1)] * Random.Range(SafeHeight, DistanceHeight);
            Vec = new Vector3(posX, PosY,0);
            ObjectPooler.Instance.SpawnFromPool(Enemy.tag, Vec, Player.transform.rotation);
            StartCoroutine(Spawn(TimeSpawn));
        } 
    }
}
