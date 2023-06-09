using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private const string ANIMATOR_VELOCITY = "Velocity";
    private const string ANIMATOR_JUMP = "Jump";

    private float velocity = 0f;
    private const float VELOCITY_ACCELERATION = 2f;
    private const float VELOCITY_DECCELERATION = 5f;

    private Player player;
    public new ParticleSystem particleSystem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        player.OnJump += Player_OnJump;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            velocity += Time.deltaTime * VELOCITY_ACCELERATION;
            if (velocity > 1f)
            {
                velocity = 1f;
            }
        }
        else
        {
            velocity -= Time.deltaTime * VELOCITY_DECCELERATION;
            if (velocity < 0f)
            {
                velocity = 0f;
            }
        }
        animator.SetFloat(ANIMATOR_VELOCITY, velocity);

        animator.SetBool(ANIMATOR_JUMP, player.IsJumping);
    }

    private void Player_OnJump()
    {
        particleSystem.Play();
    }
}
