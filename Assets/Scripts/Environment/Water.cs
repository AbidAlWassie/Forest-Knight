using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour
{

    Tilemap water;
    public bool CheckWaterHit;

    //public bool CheckWaterHit(Vector3 worldPosition)
    //{
    //    Vector3Int cellPosition = water.WorldToCell(worldPosition);
    //    TileBase tilebase = water.GetTile(cellPosition);

    //    return false;
    //}
}
