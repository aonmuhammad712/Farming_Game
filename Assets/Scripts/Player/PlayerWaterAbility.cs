using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerWaterAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator playerAnimator;
    private PlayerToolSelector toolSelector;
    [Header("Settings")]
    private CropField currentCropField;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        toolSelector = GetComponent<PlayerToolSelector>();
        WaterParticles.onWaterCollided += WaterCollidedCallback;
        CropField.onFullySown += CropFieldFullyWateredCallback;
        PlayerToolSelector.OnToolSelected += ToolSelectedCallback;
    }
    private void OnDestroy()
    {
        CropField.onFullySown -= CropFieldFullyWateredCallback;
        WaterParticles.onWaterCollided -= WaterCollidedCallback;
        PlayerToolSelector.OnToolSelected -= ToolSelectedCallback;
    }

    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!toolSelector.CanWater())
            playerAnimator.StopWaterAnimation();
    }

    private void CropFieldFullyWateredCallback(CropField cropField)
    {
        if (cropField == currentCropField)
            playerAnimator.StopWaterAnimation();
    }

    private void WaterCollidedCallback(Vector3[] waterPositions)
    {
        if (currentCropField == null)
            return;
        currentCropField.WaterCollidedCallback(waterPositions);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnteredCropField(CropField cropField)
    {
        if (toolSelector.CanWater())
        {
            if (currentCropField == null)
                currentCropField = cropField;
            playerAnimator.PlayWaterAnimation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cropfield")   )
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("cropfield"))
        {
            playerAnimator.StopWaterAnimation();
            currentCropField = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cropfield") && other.GetComponent<CropField>().IsSown())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(other.GetComponent<CropField>());
        }

    }
}
