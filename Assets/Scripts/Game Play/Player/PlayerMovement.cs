using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Variable")]
    [SerializeField] float speedPlayer;
    [SerializeField] float jumpPlayer;

    [SerializeField] LayerMask jumpableGround;
    [SerializeField] AudioSource jumpAudio;

    private float dirX;
    private enum MovementState { idle, running, jumping, falling };

    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("Dash Variable")]
    [SerializeField] float dashVelocity = 14f;
    [SerializeField] float dashTime = 0.5f;

    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;

    private TrailRenderer trailRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        MovePlayer();

        JumpPlayer();

        UpdateAnimateState();

        PlayerDash();
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

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // mengatur cara player berjalan
    private void MovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speedPlayer, rb.velocity.y);
    }

    // mengatur cara player lompat
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPlayer);
            jumpAudio.Play();
        }
    }

    // cek player apakah menyentuh tanah?
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    // fungsi player dash
    private void PlayerDash()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            isDashing = true;
            canDash = false;
            trailRenderer.emitting = true;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDash());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashVelocity;
            return;
        }

        if (IsGrounded())
        {
            canDash = true;
        }
    }

    // coroutine dash
    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting = false;
        isDashing = false;
    }

}
