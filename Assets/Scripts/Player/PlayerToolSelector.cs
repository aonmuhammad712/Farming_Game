using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerToolSelector : MonoBehaviour
{
    public enum Tool { noneTool, sowingTool, wateringTool, harverstingTool }
    Tool activeTool;
    [Header("Settings")]
    [SerializeField] private Color selectedToolColor;
    [Header("Elements")]
    [SerializeField] private Image[] toolImages;

    [Header("Actions")]
    public static Action<Tool> OnToolSelected;
    // Start is called before the first frame update
    void Start()
    {
        SelectTool(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTool(int i)
    {
            for (int j = 0; j < toolImages.Length ; j++)
        {
            toolImages[j].color = j == i ? Color.yellow : Color.white;
        }
        activeTool = (Tool)i;
        OnToolSelected?.Invoke(activeTool);
    }
    public bool CanSow() => activeTool == Tool.sowingTool;
    public bool CanWater() => activeTool == Tool.wateringTool;
    public bool CanHarvest() => activeTool == Tool.harverstingTool;
}
