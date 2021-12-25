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
    public GameObject Coin;
    protected Vector2 Vec;
    float posX = 0;
    float PosY = 0;
    int[] Arr = { -1, 1 };
    // Start is called before the first frame update
    void Start()
    {
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
            posX = Arr[Random.Range(0,1)]* Random.Range(SafeWitdh, DistanceWitdh) + Player.transform.position.x;
            PosY = Arr[Random.Range(0, 1)] * Random.Range(SafeHeight, DistanceHeight)+ Player.transform.position.y;
            Vec = new Vector2(posX, PosY);
            ObjectPooler.Instance.SpawnFromPool(Enemy.tag, Vec, Player.transform.rotation);
            StartCoroutine(Spawn(TimeSpawn));
        }    
    }
    private IEnumerator SpawnGold(float second)
    {
        yield return new WaitForSeconds(second);
        if (Player.active == true)
        {
            posX = Arr[Random.Range(0, 1)] * Random.Range(SafeWitdh, DistanceWitdh) + Player.transform.position.x;
            PosY = Arr[Random.Range(0, 1)] * Random.Range(SafeHeight, DistanceHeight) + Player.transform.position.y;
            Vec = new Vector2(posX, PosY);
            ObjectPooler.Instance.SpawnFromPool(Coin.tag, Vec, Player.transform.rotation);
            ObjectPooler.Instance.SpawnFromPool(Coin.tag, new Vector2(Vec.x + 0.5f, Vec.y + 0.5f), Player.transform.rotation);
            ObjectPooler.Instance.SpawnFromPool(Coin.tag, new Vector2(Vec.x + 0.5f, Vec.y), Player.transform.rotation);
            ObjectPooler.Instance.SpawnFromPool(Coin.tag, new Vector2(Vec.x, Vec.y + 0.5f), Player.transform.rotation);
            StartCoroutine(SpawnGold(TimeSpawn));
        }
    }
    public void Spanw()
    {
        reset();
        StartCoroutine(Spawn(TimeSpawn));
        StartCoroutine(SpawnGold(1.0f));
    }
    public void reset()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in Enemys)
        {
            obj.SetActive(false);
        }
        GameObject[] Coins = GameObject.FindGameObjectsWithTag(Coin.tag);
        foreach (GameObject obj in Coins)
        {
            obj.SetActive(false);
        }
    }
}
