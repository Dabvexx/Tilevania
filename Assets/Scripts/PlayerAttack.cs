using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Variables

    // Variables.
    // Def didnt steal this code from my global game jam project.
    [SerializeField]
    private float length;

    private Animator animator;

    [SerializeField]
    public LayerMask layerMask;

    public AudioSource audioSource;
    public AudioClip clipHit;
    public AudioClip clipMiss;
    public float volume = .5f;

    private Vector2 facingDir;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        facingDir = new Vector2(Mathf.Sign(Input.GetAxisRaw("Horizontal")), 0);

        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("SwordSwing");
            MeleeTryHit();
        }
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    // This too.

    public void MeleeTryHit()
    {
        GameObject meleeTest;
        meleeTest = CastMeleeRayCast();

        if (meleeTest == null)
        {
            // Missed
            Debug.Log("Player Missed");
            return;
        }

        // We hit something.
        // Kill
        meleeTest.GetComponent<MushAI>().Die();
    }

    public GameObject CastMeleeRayCast()
    {
        // Cast Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDir, length, layerMask);

        //Debug.DrawRay(transform.position, Vector2.up * length, Color.red, length);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, facingDir * hit.distance, Color.red, length);
            Debug.Log("Did hit");
            Debug.Log(hit.collider.gameObject);
            return hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, facingDir * length, Color.white);
            Debug.Log("Didn't hit");
            return null;
        }
    }

    #endregion Public Methods
}