using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
//[AddComponentMenu("Scripts/CamMover")]
public class CamMover : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private float speed = 5f;
    #endregion
    
    #region Unity Methods
    
    void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        var inputY = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector3(inputX, inputY, 0));
    }
    
    #endregion
}
