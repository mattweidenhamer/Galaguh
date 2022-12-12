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
    private float direction = 1f;
    private bool stopMovement = false;
    [SerializeField] int hitPoints;
    private bool moveForward = false;
    float moveTime = 0f;
    private int hp;
    private void Start() {
        hp = hitPoints;
    }
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
            Debug.Log("Hit a border edge");
            direction *= -1f;
            moveForward = true;
            moveTime = 0f;
        }
        else if (other.gameObject.tag == "bullet"){
            Debug.Log("Hit");
            if(--hp <= 0){
                blow_up();
                
            }
        }
        else if (other.gameObject.tag == "Obstacle"){
            blow_up();
        }
        else if (other.gameObject.tag == "Player"){
            stopMovement = true;
            //Do some kind of victory animation
        }

    }
    private void blow_up(){
        moveSpeed = 0f;
        GetComponent<Collider2D>().enabled = false;
        
    }
}
