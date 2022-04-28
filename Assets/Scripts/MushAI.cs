using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushAI : MonoBehaviour
{
    #region Variables

    // Variables.

    [SerializeField] private float walkTimer;
    [SerializeField] private float walkTime;
    public bool isWalking;
    public bool isAlive = true;
    public int walkDirection;
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float walkChance = 1f;

    // Wanted to do delegates, just refrence the script directly 4head
    // public delegate void DeathDelegate();
    //public event DeathDelegate deathEvent;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Die();
        }
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

    private void DecrementTimer()
    {
        if (walkTimer < 0)
        {
            isWalking = false;
            return;
        }

        walkTimer -= Time.deltaTime;
    }

    public void Die()
    {
        // Haha funni death event delegate.
        // A little too much tomfoolery.

        //if (deathEvent != null)
        //{
        //    deathEvent();
        //}

        isAlive = false;
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    #endregion Public Methods
}