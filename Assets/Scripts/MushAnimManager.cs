using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushAnimManager : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private Animator animator;

    [SerializeField] private string currentState;

    [SerializeField] private MushAI AI;

    #endregion Variables

    #region Animation States

    private const string MUSH_IDLE = "Mush_Idle";
    private const string MUSH_RUN = "Mush_Run";
    private const string MUSH_DEAD = "Mush_Dead";
    private const string MUSH_HURT = "Mush_Hurt";

    #endregion Animation States

    #region Unity Methods

    private void Start()
    {
        AI = GetComponent<MushAI>();
        animator = GetComponent<Animator>();
        ChangeAnimationState(MUSH_IDLE);
    }

    private void Update()
    {
        HandleAnim();
        FlipSprite(AI.walkDirection);
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    private void HandleAnim()
    {
        if (AI.isWalking)
        {
            ChangeAnimationState(MUSH_RUN);
        }
        else
        {
            ChangeAnimationState(MUSH_IDLE);
        }
    }

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

    private Vector2 RandomVector2(float min, float max)
    {
        Vector2 randVector2;

        randVector2.x = Random.Range(min, max);
        randVector2.y = Random.Range(min, max);

        return randVector2;
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}