using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public int tileLenght = 150;
    public float lifeTime = 5f;
    private int actualTilesPosition = 0;
    private List<GameObject> tilesSpawned;

    public static TilesGenerator Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        this.actualTilesPosition = this.tileLenght * 3;
        this.tilesSpawned = new List<GameObject>();
    }

    public void SpawnTile()
    {
        int tileNum = Random.Range(0, this.tiles.Length); // random value to take a tile from the list
        GameObject tile = Instantiate(this.tiles[tileNum], new Vector3(0, 0, this.actualTilesPosition), Quaternion.identity); // instation of a tile forward the last one
        tile.SetActive(true);
        this.tilesSpawned.Add(tile);

        Destroy(tile, this.lifeTime);

        this.actualTilesPosition += this.tileLenght;
    }

    public void Reset()
    {
        this.actualTilesPosition = this.tileLenght * 3;
        if (this.tilesSpawned.Count > 0)
        {
            foreach (var tile in this.tilesSpawned)
            {
                Destroy(tile);
            }
        }
        this.tilesSpawned.Clear();
    }
}
