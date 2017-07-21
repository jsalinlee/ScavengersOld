using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public static float thirst = 100.0f;
    public float footstepSpeed;
    public AudioClip[] footstepSounds;
    public AudioSource audioSource;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    private Vector2 lastMove;



    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Footsteps");

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    IEnumerator Footsteps()
    {
        while(true)
        {
            if(playerMoving)
            {
                audioSource.PlayOneShot(footstepSounds[Random.Range(0, 2)]);
            }
            yield return new WaitForSeconds(footstepSpeed);
        }
    }

    void Update()
    {
    	thirst -= 1 * Time.deltaTime;
        //movement code
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        //movement code

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//has the animator check how the player is moving in X
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));//has the animator check how the player is moving in y
        anim.SetBool("PlayerMoving", playerMoving);//sets the moving bool
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
