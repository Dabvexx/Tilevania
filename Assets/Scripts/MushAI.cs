using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MushData))]
public class MushAI : MonoBehaviour
{
    #region Variables

    // Variables.

    [SerializeField] private float walkTimer;
    [SerializeField] private float walkTime;
    public bool isWalking;
    public int walkDirection;
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float walkChance = 1f;
    private MushData md;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        md = GetComponent<MushData>();
    }

    private void Update()
    {
        // TODO: Just reset to idle after being hit.
        Move();
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.
    private void Move()
    {
        isWalking = walkTimer > 0;
        // Check to see if we are already walking.
        if (isWalking)
        {
            DecrementTimer();
            // Go walk and be free my child.
            rb.AddForce(new Vector2(walkSpeed * walkDirection * Time.deltaTime, 0));
            return;
        }

        // Randomly decide to move or not.

        if (Random.Range(1, walkChance * 1000) < 2)
        {
            isWalking = true;
            walkTimer = walkTime;

            walkDirection = Random.Range(1, 21) > 10 ? -1 : 1;
        }
    }

    private void Hurt(int damage)
    {
        md.health -= damage;
    }

    private void DecrementTimer()
    {
        if (walkTimer < 0)
        {
            isWalking = false;
            return;
        }

        walkTimer -= Time.deltaTime;
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}