using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float forwardMove;
    private float moveSpeedModifier;
    private float direction = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * direction * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "border r" || other.gameObject.tag == "border l"){
            Debug.Log("Hit a border edge");
            direction *= -1f;
            transform.Translate(0, forwardMove * -1f, 0);
        }
        else if (other.gameObject.tag == "Player"){
            //Do some kind of victory animation
        }
    }
}
