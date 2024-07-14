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
        Debug.Log(vector.magnitude);
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

    private void PlayRunAnimation()
    {
        animator.Play("Run");
    }

    private void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }
}
