using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private MobileJoyStick joyStick;
    private CharacterController characterController;
    private PlayerAnimator playerAnimator;
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovementMethod();
    }
    private void ManageMovementMethod()
    {
        Vector3 moveVector = joyStick.GetMoveVector() * moveSpeed * Time.deltaTime / Screen.width;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        characterController.Move(moveVector);
        playerAnimator.ManageAnimations(moveVector);
    }

}
