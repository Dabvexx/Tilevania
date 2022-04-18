using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Parallax background / foreground movement manager
///</summary>
//[AddComponentMenu("Scripts/Parallax")]
public class Parallax : MonoBehaviour
{
    #region Variables
    // Variables.
    private float length;
    private float startPosX;
    private float startPosY;
    private GameObject cam;
    
    public float horizontalParallaxEffect;

    [Header("Vertical Scrolling Variables")]
    public bool isVerticallyScrolling = false;
    public float verticalParallaxEffect;
    public float minVerticalScroll;
    public float maxVerticalScroll;
    #endregion

    #region Unity Methods

    void Start()
    {
        cam = Camera.main.gameObject;
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        HorizonalParallax();
        if (isVerticallyScrolling)
        {
            VerticalScrolling();
        }
    }

    #endregion

    #region Private Methods

    private void HorizonalParallax()
    {
        float distX = (cam.transform.position.x * horizontalParallaxEffect);

        // Offset from original starting position
        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
        HorizontalLoop();
    }

    private void HorizontalLoop()
    {
        float temp = (cam.transform.position.x * (1 - horizontalParallaxEffect));

        if (temp > startPosX + length) startPosX += length;
        else if (temp < startPosX - length) startPosX -= length;
    }

    private void VerticalScrolling()
    {
        // Currently this doesnt do anything.
        // I tried to use the offset code for the vertical access
        // However, its actually just moving as the camera moves and being constrained

        float distY = (cam.transform.position.y * verticalParallaxEffect);

        transform.position = new Vector3(transform.position.x, startPosY  + distY, transform.position.z);

        // Constrain the height offset.
        //Mathf.Clamp(transform.localPosition.y, minVerticalScroll, maxVerticalScroll);
        ConstrainVerticalAxis();
    }

    private void ConstrainVerticalAxis()
    {
        if (transform.localPosition.y < minVerticalScroll)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, minVerticalScroll, transform.localPosition.z);
        }
        else if (transform.localPosition.y > maxVerticalScroll)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxVerticalScroll, transform.localPosition.z);
        }

    }
    #endregion Private Methods
}
