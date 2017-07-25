using UnityEngine;
using System.Collections;

public class EnemyEyeController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timebetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 movedirection;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        timebetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = movedirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timebetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timebetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (timebetweenMoveCounter < 0f)
            moving = true;
            timeToMoveCounter = timeToMove;

            movedirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
        }
    }


}