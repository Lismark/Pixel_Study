using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour

{
    [SerializeField] private GameObject LeftBorder;
    [SerializeField] private GameObject RightBorder;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private bool isRightDirection; 
    [SerializeField] private float speed;
    [SerializeField] private GroundDetection groundDetection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollDamage collDamageScript;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetBool("isWalking", true);
    }

    private void FixedUpdate() {

        if (groundDetection.IsGrounded)
        {
            if(gameObject.transform.position.x > RightBorder.transform.position.x 
                || collDamageScript.Direction > 0) 
            { 
                isRightDirection = false;
            }
            if (gameObject.transform.position.x < LeftBorder.transform.position.x 
                || collDamageScript.Direction < 0)
            {
                isRightDirection = true;
            }
            
            rigidBody.velocity = isRightDirection ? Vector2.right : Vector2.left;
            rigidBody.velocity *= speed;

        }


        if (isRightDirection)
            spriteRenderer.flipX = true;
        if (!isRightDirection)
            spriteRenderer.flipX = false;

    }

 
}
