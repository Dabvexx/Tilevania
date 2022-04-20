using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Variables
    // Variables.
    public static GameEvents current;

    #endregion

    #region Unity Methods

    void Awake()
    {
        current = this;
    }

    #endregion

    #region Private Methods
    // Private Methods.

    #endregion

    #region Public Methods
    // Public Methods.
    public event Action onPlaySound;
    public void PlaySound()
    {
        if(onPlaySound != null)
        {
            onPlaySound();
        }
    }
    #endregion
}