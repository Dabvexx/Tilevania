using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    #region Variables
    // Variables.
    Animator animator;
    #endregion

    #region Unity Methods

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log(input);

        HandleRunning(input.x);
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private void FlipSprite(float input)
    {
        transform.localScale = new Vector2(Mathf.Sign(input), 1f);
    }

    private void HandleRunning(float input)
    {
        if (input == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            FlipSprite(input);
        }
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}