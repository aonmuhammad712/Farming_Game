using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = " Crop Data", menuName = "Scriptable Ojbects / Crop Data", order = 0)]
public class CropData : ScriptableObject
{
    [Header("Settings")]
    public Crop cropPrefab;
}
