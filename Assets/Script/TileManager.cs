﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private Transform spawnPoints;
    private Vector3 prePos;
    public float spritePixels = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        prePos = playerTransform.position;
        SpawnTile(playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player pos: " + playerTransform.position.x + " " +playerTransform.position.y);
        Debug.Log("Pre Pos: " + prePos.x + " " + prePos.y);
        if (isOutOfLimit(playerTransform.position,spritePixels*1.5f))
        {
            SpawnTile(playerTransform.position);
            prePos = playerTransform.position;
        }
    }
    
    bool isOutOfLimit(Vector3 pos, float limit)
    {
        if (pos.x>prePos.x+limit || pos.y>prePos.y+limit || pos.x<prePos.x-limit || pos.y<prePos.y-limit)
            return true;
        return false;
    }
    private void SpawnTile(Vector2 pos)
    {
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x + spritePixels, pos.y + spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x , pos.y + spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x - spritePixels, pos.y + spritePixels, 0), Quaternion.identity);

        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x + spritePixels, pos.y, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x , pos.y, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x - spritePixels, pos.y, 0), Quaternion.identity);

        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x + spritePixels, pos.y - spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x, pos.y - spritePixels, 0), Quaternion.identity);
        Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(pos.x - spritePixels, pos.y - spritePixels, 0), Quaternion.identity);
    }
}
