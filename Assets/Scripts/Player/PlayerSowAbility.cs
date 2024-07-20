using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSowAbility : MonoBehaviour
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
        SeedParticles.onSeedCollided += SeedsCollidedCallback;
        CropField.onFullySown += CropFieldFullySownCallback;
        PlayerToolSelector.OnToolSelected += ToolSelectedCallback; 
    }
    private void OnDestroy()
    {
        CropField.onFullySown -= CropFieldFullySownCallback;
        SeedParticles.onSeedCollided -= SeedsCollidedCallback;
        PlayerToolSelector.OnToolSelected -= ToolSelectedCallback;
    }

    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!toolSelector.CanSow())
            playerAnimator.StopSowAnimation();
    }

    private void CropFieldFullySownCallback(CropField cropField)
    {
        if (cropField == currentCropField)
            playerAnimator.StopSowAnimation();
    }

    private void SeedsCollidedCallback(Vector3[] seedPositions)
    {
        if (currentCropField == null)
            return;
        currentCropField.SeedsCollidedCallback(seedPositions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnteredCropField(CropField cropField)
    {
        if(toolSelector.CanSow())
        playerAnimator.PlaySowAnimation();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cropfield") && other.GetComponent<CropField>().IsEmpty())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField); 
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("cropfield"))
        {
            playerAnimator.StopSowAnimation();
            currentCropField = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cropfield"))
            EnteredCropField(other.GetComponent<CropField>());

    }
}
