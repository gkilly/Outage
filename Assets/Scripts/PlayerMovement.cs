using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private float currentDistanceToWaypoint;
    private float previousDistanceToWaypoint;
    private int lastDirection;
    private int currDirection;
    public Transform[] waypointChoices = new Transform[4];
    private Vector3 nextMove;

    public bool movement = false;
    private Rigidbody2D theRigidbody;
    public GameObject leftWaypointCollider;
    public GameObject rightWaypointCollider;
    public GameObject upWaypointCollider;
    public GameObject downWaypointCollider;
    private Transform lastWaypoint = null;
    private Transform currWaypoint = null;
    // Use this for initialization
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        leftWaypointCollider = GameObject.Find("leftCollider");
        rightWaypointCollider = GameObject.Find("rightCollider");
        upWaypointCollider = GameObject.Find("upCollider");
        downWaypointCollider = GameObject.Find("downCollider");

       // currWaypoint =
        waypointChoices[2] = GameObject.Find("SecondWaypoint").transform;
        lastDirection = -1;
        currDirection = 2;
    }
    // Update is called once per frame
    void Update () {
        if (movement)
        {
            currentDistanceToWaypoint = (currWaypoint.position - transform.position).magnitude;

            nextMove = (currWaypoint.position - transform.position).normalized;
            theRigidbody.velocity = new Vector2(nextMove.x * speed, nextMove.y * speed);


            if (currentDistanceToWaypoint < 0.1)
            {
                movement = false;
                print("wtf");
                theRigidbody.velocity = Vector2.zero;
                RaycastHit2D downRay = Physics2D.Raycast(downWaypointCollider.transform.position, Vector2.down, Mathf.Infinity);
                RaycastHit2D upRay = Physics2D.Raycast(upWaypointCollider.transform.position, Vector2.up, Mathf.Infinity);
                RaycastHit2D leftRay = Physics2D.Raycast(leftWaypointCollider.transform.position, Vector2.left, Mathf.Infinity);
                RaycastHit2D rightRay = Physics2D.Raycast(rightWaypointCollider.transform.position, Vector2.right, Mathf.Infinity);

                if (upRay.collider == true)
                {
                    print("hey");
                    if (upRay.collider.gameObject.layer == LayerMask.NameToLayer("Waypoint"))
                    {
                        print(upRay.collider.name);
                        waypointChoices[0] = upRay.collider.transform;
                    }
                    else
                        waypointChoices[0] = null;
                }
                else
                    waypointChoices[3] = null;

                if (rightRay.collider == true)
                {
                    print("right");
                    if (rightRay.collider.gameObject.layer == LayerMask.NameToLayer("Waypoint"))
                    {
                        print(rightRay.collider.name);
                        waypointChoices[1] = rightRay.collider.transform;
                    }
                    else
                        waypointChoices[1] = null;
                }
                else
                    waypointChoices[1] = null;

                if (downRay.collider == true)
                {
                    print(downRay.collider.name);
                    if (downRay.collider.gameObject.layer == LayerMask.NameToLayer("Waypoint"))
                    {
                        print(downRay.collider.name);
                        waypointChoices[2] = downRay.collider.transform;
                    }
                    else
                        waypointChoices[2] = null;
                }
                else
                    waypointChoices[2] = null;

                if (leftRay.collider == true)
                {
                    print("left");
                    if (leftRay.collider.gameObject.layer == LayerMask.NameToLayer("Waypoint"))
                    {
                        print(leftRay.collider.name);
                        waypointChoices[3] = leftRay.collider.transform;
                    }
                    else
                        waypointChoices[3] = null;
                }
                else
                    waypointChoices[3] = null;
            }

            GetComponent<Animator>().SetBool("isMoving", movement);
            GetComponent<Animator>().SetInteger("direction", currDirection);

            /* if (currDirection % 2 == 1 && lastDirection % 2 == 1 && ((Input.GetAxis("Horizontal") < 0 && theRigidbody.velocity.x > 0) || Input.GetAxis("Horizontal") > 0 && theRigidbody.velocity.y < 0))
             {
                 Transform temp = currWaypoint;
                 currWaypoint = lastWaypoint;
                 lastWaypoint = temp;
             }
             if (currDirection % 2 == 0 && lastDirection % 2 == 0 && ((Input.GetAxis("Vertical") < 0 && theRigidbody.velocity.x > 0) || Input.GetAxis("Vertical") > 0 && theRigidbody.velocity.y < 0))
             {
                 Transform temp = currWaypoint;
                 currWaypoint = lastWaypoint;
                 lastWaypoint = temp;
             }*/
        }
        else
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if (inputY > 0 && waypointChoices[0] != null)
            {
                movement = true;
                lastWaypoint = currWaypoint;
                currWaypoint = waypointChoices[0];
                lastDirection = currDirection;
                currDirection = 0;
            }
            else if(inputY < 0 && waypointChoices[2] != null)
            {
                movement = true;
                lastWaypoint = currWaypoint;
                currWaypoint = waypointChoices[2];
                lastDirection = currDirection;
                currDirection = 2;
            }
            else if(inputX > 0 && waypointChoices[1])
            {
                movement = true;
                lastWaypoint = currWaypoint;
                currWaypoint = waypointChoices[1];
                lastDirection = currDirection;
                currDirection = 1;
            }
            else if(inputX < 0 && waypointChoices[3] != null)
            {
                movement = true;
                lastWaypoint = currWaypoint;
                currWaypoint = waypointChoices[3];
                lastDirection = currDirection;
                currDirection = 3;
            }
        }

    }
}
