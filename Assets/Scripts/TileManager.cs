using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Tiles/TileManager.cs - modified by Lynn Pham 
public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tilelength = 30;
    public int numberOfTiles = 7;
    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameObject.FindWithTag("Player").transform;
        for (int i=0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // playertransform oriented
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tilelength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    //spawn a tile 
    public void SpawnTile(int tileIdx)
    {
        GameObject go = Instantiate(tilePrefabs[tileIdx], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tilelength;
    }

    //deleted spawned tile that player has already passed
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
