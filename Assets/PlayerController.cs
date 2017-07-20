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

    private bool playerMoving;
    private Vector2 lastMove;



    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Footsteps");
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
