using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {

        //movement code
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        //movement code

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//has the animator check how the player is moving in X
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));//has the animator check how the player is moving in y
        anim.SetBool("PlayerMoving", playerMoving);//sets the moving bool
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}