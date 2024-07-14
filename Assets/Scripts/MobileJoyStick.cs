using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoyStick : MonoBehaviour
{
    [Header("Elementes")]
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickKnob;
    [Header("Settings")]
    [SerializeField] float moveFactor;
    private bool canControl;
    private Vector3 clickedPostion;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {

        if (canControl)
            ControlJoystick();
    }
    public void ClickedOnJoystickZoneCallback()
    {
        ShowJoystick();
         clickedPostion = Input.mousePosition;
        joystickOutline.position = clickedPostion;
    }
    private void ShowJoystick()
    {
        canControl = true;
        joystickOutline.gameObject.SetActive(true);
    }
    private void HideJoystick()
    {
        move = Vector3.zero;
        canControl = false;
        joystickOutline.gameObject.SetActive(false);
    }

    private void ControlJoystick()
    {
        Vector3 currentPostion = Input.mousePosition;
        Vector3 direction = currentPostion - clickedPostion;
        float moveMagnitude = direction.magnitude * moveFactor / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);
         move = direction.normalized * moveMagnitude;
        Vector3 tarpgetPosition = clickedPostion + move;
        joystickKnob.position = tarpgetPosition;
        if(Input.GetMouseButtonUp(0))
        {
            HideJoystick();
        }
    }
    public Vector3 GetMoveVector() => move;
}
