using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedPlayer;
    [SerializeField] float jumpPlayer;

    private float dirX;
    private enum MovementState { idle, running, jumping, falling };

    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();

        JumpPlayer();

        UpdateAnimateState();
    }

    // mengatur pergantian animasi
    private void UpdateAnimateState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // mengatur cara player bergerak
    private void MovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speedPlayer, rb.velocity.y);
    }

    // mengatur cara palyer lompat
    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPlayer);
        }
    }
}
