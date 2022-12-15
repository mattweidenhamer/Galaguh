using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guh : MonoBehaviour
{
    [SerializeField] Sprite noneSprite;
    [SerializeField] float shootDelay = 0f;
    [SerializeField] GameObject bulletPrefab;

    private float timeSinceLastShot = 0f;
    private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = noneSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //Fire Controls
        if (Input.GetButton("Fire1") && canFire) {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
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
}
