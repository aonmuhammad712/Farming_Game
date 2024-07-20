using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator playerAnimator;
    [Header("Settings")]
    private CropField currentCropField;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        SeedParticles.onSeedCollided += SeedsCollidedCallback;
        CropField.onFullySown += CropFieldFullySownCallback;
    }
    private void OnDestroy()
    {
        CropField.onFullySown -= CropFieldFullySownCallback;
        SeedParticles.onSeedCollided -= SeedsCollidedCallback;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cropfield") && other.GetComponent<CropField>().IsEmpty())
        {
            playerAnimator.PlaySowAnimation();
            currentCropField = other.GetComponent<CropField>();
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
}
