using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private const float GRAVITY = -9.81f;
    private Vector3 gravityVelocity = Vector3.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateCursor();
        UpdateTransform();
    }

    private void UpdateCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void UpdateTransform()
    {
        Vector2 inputVector = GetNormalizedInputVector();
        Vector3 direction = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * new Vector3(inputVector.x, 0f, inputVector.y);
        if (direction != Vector3.zero)
        {
            const float ROTATE_SPEED = 10f;
            transform.forward = Vector3.Slerp(transform.forward, direction, ROTATE_SPEED * Time.deltaTime);
        }
        const float SPEED = 3f;
        characterController.Move(SPEED * Time.deltaTime * direction);
        if (characterController.isGrounded)
        {
            gravityVelocity.y = 0f;
        }
        gravityVelocity.y += GRAVITY * Time.deltaTime;
        characterController.Move(Time.deltaTime * gravityVelocity);
    }

    private Vector2 GetNormalizedInputVector()
    {
        Vector2 inputVector = new();
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1f;
        }
        return inputVector.normalized;
    }
}
