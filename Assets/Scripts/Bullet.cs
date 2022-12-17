using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Sprite explodeSprite;
    [SerializeField] float timeToDespawn;
    bool stopped = false;
    void Update()
    {
        if(!stopped){
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D other) {
        StartCoroutine("explode");
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    IEnumerator explode(){
        stopped=true;
        GetComponent<SpriteRenderer>().sprite = explodeSprite;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Debug.Log("Started exploding");
        yield return new WaitForSeconds(timeToDespawn);
        Debug.Log("Done exploding, time to destroy!");
        Destroy(gameObject);
    }
    
}
