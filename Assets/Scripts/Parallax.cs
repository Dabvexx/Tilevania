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
    private float startPos;
    public GameObject cam;
    public float horizontalParallaxEffect;

    public float verticalParallaxEffect;
    public float minVerticalScroll;
    public float maxVerticalScroll;
    #endregion

    #region Unity Methods

    void Start()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        HorizonalParallax();
    }

    #endregion

    #region Private Methods

    private void HorizonalParallax()
    {
        float dist = (cam.transform.position.x * horizontalParallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        HorizontalLoop();
    }

    private void HorizontalLoop()
    {
        float temp = (cam.transform.position.x * (1 - horizontalParallaxEffect));

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }

    private void VerticalScrolling()
    {
        float dist = (cam.transform.position.y * verticalParallaxEffect);
    }
    #endregion Private Methods
}
