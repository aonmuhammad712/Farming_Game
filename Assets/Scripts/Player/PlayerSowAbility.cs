using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cropfield"))
        {
            playerAnimator.PlaySowAnimation();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("cropfield"))
        {
            playerAnimator.StopSowAnimation();
        }
    }
}
