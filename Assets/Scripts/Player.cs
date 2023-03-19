using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        Vector2 inputVector = GetNormalizedInputVector();
        if (inputVector == Vector2.zero)
        {
            return;
        }
        Vector3 direction = new(inputVector.x, 0f, inputVector.y);
        const float ROTATE_SPEED = 10f;
        transform.forward = Vector3.Slerp(transform.forward, direction, ROTATE_SPEED * Time.deltaTime);
        const float SPEED = 3f;
        transform.position += SPEED * Time.deltaTime * direction;
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
