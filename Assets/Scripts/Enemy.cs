using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject[] waypoints;
    //private int currentWP = 0;
    [SerializeField] float moveSpeed;
    //[SerializeField] float forwardMove;
    [SerializeField] float turnDistance;
    [SerializeField] float timeToMoveForward;
    [SerializeField] int hitPoints;
    [SerializeField] int bountyPoints;
    private float direction = 1f;
    private bool stopMovement = false;
    private bool moveForward = false;
    

    float moveTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(!stopMovement){
            //transform.LookAt(waypoints[currentWP].transform);
            //Removed direction from below, maybe bring back?
            if(moveForward){
                transform.position +=  (Vector3.down * moveSpeed) * Time.deltaTime;
                moveTime += Time.deltaTime;
                if (moveTime > timeToMoveForward){
                    moveForward = false;
                }
            }
            else{
                transform.position += (Vector3.right * moveSpeed * direction) * Time.deltaTime;
                //transform.Translate(moveSpeed * Time.deltaTime * direction, 0, 0);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "border r" || other.gameObject.tag == "border l"){
            direction *= -1f;
            moveForward = true;
            moveTime = 0f;
        }
        else if (other.gameObject.tag == "bullet"){
            if(--hitPoints <= 0){
                FindObjectOfType<Scoreboard>().gainScore(bountyPoints);
                BlowUp();
            }
        }
        else if (other.gameObject.tag == "obstacle"){
            BlowUp();
        }
        else if (other.gameObject.tag == "Player"){
            stopMovement = true;
            //Do some kind of victory animation
        }
    }
    private void BlowUp()
    {
        moveSpeed = 0f;    
        GetComponent<Collider2D>().enabled = false;
        GetComponent<BlowUpScript>().startExplosion();
    }
}
