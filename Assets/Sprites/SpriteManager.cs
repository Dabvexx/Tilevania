using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    #region Variables
    // Variables.
    
    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            FlipSprite();
        }
    }

    #endregion

    #region Private Methods
    // Private Methods.
    void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")), 1f);
    }

    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}