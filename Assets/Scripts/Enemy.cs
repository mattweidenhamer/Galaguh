using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWP = 0;
    [SerializeField] float moveSpeed;
    [SerializeField] float forwardMove;
    [SerializeField] float turnDistance;
    private float direction = 1f;
    private bool stopMovement = false;
    [SerializeField] int hitPoints;

    // Update is called once per frame
    void Update()
    {
        if(!stopMovement){
            //transform.LookAt(waypoints[currentWP].transform);
            //Removed direction from below, maybe bring back?
            transform.Translate(moveSpeed * Time.deltaTime * direction, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "border r" || other.gameObject.tag == "border l"){
            Debug.Log("Hit a border edge");
            direction *= -1f;
            transform.Translate(0, forwardMove * -1f, 0);
        }
        else if (other.gameObject.tag == "Bullet"){
            hitPoints--;
            if(hitPoints <= 0){
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Player"){
            stopMovement = true;
            //Do some kind of victory animation
        }

    }
}
