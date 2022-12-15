using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField] float moveModifier = 0f;
    private bool limitR = false;
    private bool limitL = false;
    private Rigidbody2D body;
    private Scoreboard scoreboard;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        scoreboard = FindObjectOfType<Scoreboard>();
    }
    // Update is called once per frame
    void Update()
    {

        //Movement
        float movement = Input.GetAxis("Horizontal");
        if(!(limitR && movement>0) && !(limitL && movement<0)){
            transform.Translate(movement * moveModifier * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Limit movement if you hit a border
        if(other.gameObject.tag == "border l"){
            limitL = true;
        } else if(other.gameObject.tag == "border r"){
            limitR = true;
        }
        else if(other.gameObject.tag == "enemy" || other.gameObject.tag == "obstacle"){
            defeat();
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
    }
    private void defeat(){
        limitL = true;
        limitR = true;
        GetComponent<Collider2D>().enabled = false;
        scoreboard.defeated();
        GetComponent<BlowUpScript>().startExplosion();
        GetComponentInChildren<Guh>().enabled = false;
    }

}
