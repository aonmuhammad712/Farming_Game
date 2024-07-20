using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TileFieldState
{
    Empty, Sown, Watered
}
public class CropTile : MonoBehaviour
{
   
    private TileFieldState state;
    [Header("Elements")]
    [SerializeField] private Transform cropParent;
    // Start is called before the first frame update
    void Start()
    {
        state = TileFieldState.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool IsEmpty()
    {
        return state == TileFieldState.Empty;
    }

    internal void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
       if(state == TileFieldState.Sown)
        {
            Crop crop = Instantiate(cropData.cropPrefab, transform.position, Quaternion.identity, cropParent);
        }
    }
}
