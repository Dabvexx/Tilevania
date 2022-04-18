using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
//[AddComponentMenu("Scripts/TransformConstrainer")]
public class TransformConstrainer : MonoBehaviour
{
    #region Variables
    // Variables.
    // Vector2 variables: x is the min, y is the max.
    public bool constrainX;
    public Vector2 rangeX;
    public bool constrainY;
    public Vector2 rangeY;
    public bool constrainZ;
    public Vector2 rangeZ;
    #endregion
    
    #region Unity Methods
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    #endregion
    
    #region Private Methods
    // Private Methods.
    
    #endregion
    
    #region Public Methods
    // Public Methods.
    public void ConstrainX()
    {
        if (transform.position.x > rangeX.x)
        {

        }
    }

    public void ConstrainLocalX()
    {

    }

    public void ConstrainY()
    {

    }

    public void ConstrainLocalY()
    {

    }

    public void ConstrainZ()
    {

    }

    public void ConstrainLocalZ()
    {

    }

    public void ConstrainXY()
    {

    }

    public void ConstrainXYZ()
    {
        // Use Mathf.Clamp 4head
        //if(transform.position > new Vector3(rangeX.x, rangeY.x, rangeZ.x))
        //{

        //}
    }
    #endregion
}
