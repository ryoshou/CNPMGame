using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private Transform spawnPoints;
    private int tmp;
    public float spritePixels = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        tmp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x>20.48*tmp)
        {
            SpawnTile();
            tmp++;
        }
    }
    
    private void SpawnTile()
    {
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x + spritePixels, playerTransform.position.y + spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x , playerTransform.position.y + spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x - spritePixels, playerTransform.position.y + spritePixels, 0), Quaternion.identity);

        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x + spritePixels, playerTransform.position.y, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x , playerTransform.position.y, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x - spritePixels, playerTransform.position.y, 0), Quaternion.identity);

        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x + spritePixels, playerTransform.position.y - spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x, playerTransform.position.y - spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(playerTransform.position.x - spritePixels, playerTransform.position.y - spritePixels, 0), Quaternion.identity);
    }
}
