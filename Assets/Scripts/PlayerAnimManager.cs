using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    #region Variables

    // Variables.
    private Animator animator;

    private bool isAlive = true;
    private string currentState;
    private Vector3 prevPos;

    #endregion Variables

    #region Animation States

    private const string PLAYER_IDLE = "Idle";
    private const string PLAYER_RUN = "Run";
    private const string PLAYER_ACCEND = "Accending";
    private const string PLAYER_DECEND = "Decending";
    private const string PLAYER_DEAD = "Dead";

    #endregion Animation States

    #region Unity Methods

    private void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState(PLAYER_IDLE);
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        HandleAnim(input.x);
        FlipSprite(input.x);

        prevPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isAlive = false;
        }
    }

    #endregion Unity Methods

    #region Private Methods

    private void HandleAnim(float inputX)
    {
        // Check if deceseaed (L + Ratio)
        if (!isAlive)
        {
            ChangeAnimationState(PLAYER_DEAD);
            return;
        }

        // Check if accending.
        if (transform.position.y > prevPos.y)
        {
            ChangeAnimationState(PLAYER_ACCEND);
            return;
        }

        // Check if decending.
        else if (transform.position.y < prevPos.y)
        {
            ChangeAnimationState(PLAYER_DECEND);
            return;
        }

        // Check if idle.
        if (inputX == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }

        // Check if idle.
        else
        {
            ChangeAnimationState(PLAYER_RUN);
        }
    }

    // Private Methods.
    private void FlipSprite(float input)
    {
        if (input == 0) return;
        transform.localScale = new Vector2(Mathf.Sign(input), 1f);
    }

    private void ChangeAnimationState(string newState)
    {
        // Dont interupt itself.
        if (currentState == newState) return;

        // Play the animation.
        animator.Play(newState);

        // Reassign the current state

        currentState = newState;
    }

    #endregion Private Methods
}