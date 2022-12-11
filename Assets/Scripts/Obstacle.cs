using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int minHP;
    [SerializeField] int maxHP;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    private Collider2D thisCollider;
    private int hitpoints;
    private float size;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = Random.Range(minHP, maxHP);
        size = Random.Range(minSize, maxSize);
        thisCollider = GetComponent<Collider2D>();
        speed = Random.Range(minSpeed, maxSpeed);


        //Randomly choose an angle and assign it to angle
        transform.Rotate(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * -1, 0f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "bullet"){
            if(--hitpoints <= 0){
                Debug.Log("Destroyed");
                Destroy(gameObject);
            }
            else{
                //Set this object's sprite to a different one based on the number of hp available 
            }
        }
    }
}
