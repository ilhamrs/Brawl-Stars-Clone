using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] JoystickScript joystickScript;
    [SerializeField] JoystickScript rightJoystick;

    public GameObject capsule;

    float walkSpeed = 10f;

    Vector3 moveDirection = Vector3.zero;

    CharacterController characterController;

    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = walkSpeed * Input.GetAxis("Vertical");
        float curSpeedY = walkSpeed * Input.GetAxis("Horizontal");

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(moveDirection * Time.deltaTime);

        if (joystickScript.inputDir != Vector2.zero)
        {
            moveDirection = (forward * walkSpeed * joystickScript.inputDir.y) + (right * walkSpeed * joystickScript.inputDir.x);

            characterController.Move(moveDirection * Time.deltaTime);
        }

        if (rightJoystick.inputDir != Vector2.zero)
        {
            capsule.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(rightJoystick.inputDir.x, rightJoystick.inputDir.y) * 180 / Mathf.PI, 0f);

            playerAttack.Fire();
        }

    }
}
