using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject tilePrefab;
    Vector3 pos;
    GameObject tile;
    [Range(0,1)] public float outlinePercent;
    private bool isBroken;



    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
         
    }

    public void GenerateGrid()
    {
        string holderName = "GeneratedGrid";

        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform gridHolder = new GameObject(holderName).transform;
        gridHolder.parent= transform;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                pos = new Vector3(-width / 2 + 0.5f + x, 0, -height / 2 + 0.5f + z);
                tile = Instantiate(tilePrefab, pos, Quaternion.identity);

                tile.name = (x + "," + z);
                tile.transform.localScale = Vector3.one * (1 - outlinePercent);
                tile.transform.parent= gridHolder;


            }
        }
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;  
    }
}
