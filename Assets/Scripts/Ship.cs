using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float moveModifier = 0f;
    [SerializeField] float shootDelay = 0f;

    private float timeSinceLastShot = 0f;
    private bool canFire = true;
    private bool limitR = false;
    private bool limitL = false;
    private Rigidbody2D body;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        //Movement
        float movement = Input.GetAxis("Horizontal");
        if(!(limitR && movement>0) && !(limitL && movement<0)){
            transform.Translate(movement * moveModifier * Time.deltaTime, 0, 0);
        }
        //Fire Controls
        if (Input.GetButton("Fire1") && canFire) {
            Debug.Log("Pew");
            canFire = false;
            timeSinceLastShot = 0f;
        }
        else if (!canFire){
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot > shootDelay){
                canFire = true;
            }
        }

        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Limit movement if you hit a border
        if(other.gameObject.tag == "border l"){
            limitL = true;
        } else if(other.gameObject.tag == "border r"){
            limitR = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        //Limit movement if you hit a border
        if(other.gameObject.tag == "border l"){
            limitL = false;
        }
        else if(other.gameObject.tag == "border r"){
            limitR = false;
        }
        else if(other.gameObject.tag == "enemy"){
            defeat();
        }
    }
    private void defeat(){
        limitL = true;
        limitR = true;
        //Flash score on screen
        //Some kind of menu?
    }


}