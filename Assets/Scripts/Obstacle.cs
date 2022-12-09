using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int minHP;
    private int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = Random.Range(minHP, maxHP);
        //Randomly choose an angle and assign it to angle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "bullet"){
            if(--hitpoints <= 0){
                Debug.Log("Destroyed");
                Destroy(gameObject);
            }
            else{
                //Set this object's sprite to a different one based on the number of 
            }
        }
    }
}
