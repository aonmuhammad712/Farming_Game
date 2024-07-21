using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform cropRendererTansform;
   public void ScaleUp()
    {
        cropRendererTansform.localScale = Vector3.one;
    }
}
