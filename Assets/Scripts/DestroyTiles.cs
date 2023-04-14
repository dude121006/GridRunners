using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyTiles : MonoBehaviour
{
    GridGenerator gridGenerator;
    public GameObject grid;
    public float timeBetweenBreak = 3;
    public float timeBetweenDestroy = 3;
    float nextBreakTime; 
    float nextDestroyTime;
    bool isBroken;
    public bool chooseRandomTile;
    public Material materialToSwap;

    void Awake()
    {
        gridGenerator = grid.GetComponent<GridGenerator>();
    }

    void Update()
    {
        if (Time.time >= nextBreakTime)
        {
            nextBreakTime = Time.time + timeBetweenBreak;
            ChooseTileToDestroy();
        }
    }

    public void ChooseTileToDestroy()
    {
        if (chooseRandomTile)
        {
            int xToDestroy = Random.Range(0, gridGenerator.width);
            int zToDestroy = Random.Range(0, gridGenerator.height);

            //print(xToDestroy + "," + zToDestroy);
            DestroyTile(grid.transform.GetChild(0).Find(xToDestroy + "," + zToDestroy).GetChild(0).gameObject);
        }
        else
        {
            DestroyTile(grid.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
        }
    }

    public void DestroyTile(GameObject tileToDestroy)
    {
        SwapMaterial(tileToDestroy);

        BoxCollider boxCollider= tileToDestroy.GetComponent<BoxCollider>();
        boxCollider.enabled = true;

        {//tileToDestroy.Dest
         ////tileToDestroy.isBroken = true;


            //nextDestroyTime = Time.time + timeBetweenDestroy;

            ////if (Time.time >= nextDestroyTime)
            //{
            //    //Destroy(tileToDestroy);
            //}
        }

    }

    public void SwapMaterial(GameObject tileToDestroy)
    {
        tileToDestroy.GetComponent<Renderer>().material = materialToSwap;
    }
}

