using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpScript : MonoBehaviour
{
    [SerializeField] Sprite[] animationFrames;
    [SerializeField] float timeBetweenFrames;

    public void startExplosion(){
        StartCoroutine(ExplodeAnimation());
    }
    IEnumerator ExplodeAnimation()
    {
        foreach(Sprite expSprite in animationFrames){
            gameObject.GetComponent<SpriteRenderer>().sprite = expSprite;
            yield return new WaitForSeconds(timeBetweenFrames);
        }
        Destroy(gameObject);
    }
}
