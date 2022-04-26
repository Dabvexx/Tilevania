using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimeManager : MonoBehaviour
{
    #region Variables
    // Variables.
    Animator animator;
    private string currentState;
    Vector3 prevPos;
    #endregion

    #region Animation States
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_ACCEND = "Accending";
    const string PLAYER_DECEND = "Decending";
    #endregion

    #region Unity Methods

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState(PLAYER_IDLE);
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        HandleAnim(input.x);
        FlipSprite(input.x);

        prevPos = transform.position;
    }

    #endregion

    #region Private Methods

    private void HandleAnim(float inputX)
    {
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
    #endregion
}