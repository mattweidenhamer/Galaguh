using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Hit");
        Destroy(gameObject);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
