using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private const string ANIMATOR_VELOCITY = "Velocity";

    private float velocity = 0.0f;
    private const float VELOCITY_CHANGE = 2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity += Time.deltaTime * VELOCITY_CHANGE;
            if (velocity > 1.0f)
            {
                velocity = 1.0f;
            }
        }
        else
        {
            velocity -= Time.deltaTime * VELOCITY_CHANGE;
            if (velocity < 0.0f)
            {
                velocity = 0.0f;
            }
        }
        animator.SetFloat(ANIMATOR_VELOCITY, velocity);
    }
}
