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
    private Crop crop;
   [SerializeField] private MeshRenderer tileRendered;
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
    public bool IsSown() => state == TileFieldState.Sown;
    internal void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
       if(state == TileFieldState.Sown)
        {
             crop = Instantiate(cropData.cropPrefab, transform.position, Quaternion.identity, cropParent);
        }
    }
    public void Water()
    {
        state = TileFieldState.Watered;
        tileRendered.material.color = Color.white * 0.3f;
        crop.ScaleUp();
    }
}
