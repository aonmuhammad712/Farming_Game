using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Animator animator;
    [Header("Settings")]
    [SerializeField] private float moveSpeedMultiplayer;
    [SerializeField] private ParticleSystem waterParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageAnimations(Vector3 vector)
    {
        if(vector.magnitude > 0)
        {
            animator.SetFloat("moveSpeed", vector.magnitude * moveSpeedMultiplayer);
            PlayRunAnimation();
            animator.transform.forward = vector.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    internal void StopSowAnimation()
    {
        animator.SetLayerWeight(1, 0);
    }

    private void PlayRunAnimation()
    {
        animator.Play("Run");
    }

    private void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }
    public void PlaySowAnimation()
    {
        animator.SetLayerWeight(1, 1);
    }
    public void PlayWaterAnimation()
    {
        animator.SetLayerWeight(2, 1);
    }

    internal void StopWaterAnimation()
    {
        animator.SetLayerWeight(2, 0);
        waterParticles.Stop();
    }
}
