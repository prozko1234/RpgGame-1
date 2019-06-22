using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*! \brief PlayerMovement description.
 *         Handles player movement.
 *
 *  This script providse functionality for player's object's movement.
 */
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;
    private Rigidbody2D myRigidBody;
    private Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;
    public bool canMove;
    //---------------------------------------------------------------------------------
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        //Character moves
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            playerMoving = true;

        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            playerMoving = true;
        }

        //Character Stops
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentMoveSpeed = moveSpeed * diagonalMoveModifier;
        } else
        {
            currentMoveSpeed = moveSpeed;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
    //! Get last move method.
    /*!
     * Gets last Vector2 as last move.
     * \return Vector2 last move.
    */
    public Vector2 GetLastMove()
    {
        return lastMove;
    }
    //! Set last move method.
    /*!
     * Sets last Vector2 as last move
    */
    public void SetLastMove(Vector2 lastMove)
    {
        this.lastMove = lastMove;
    }
}
