using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Color32 hasPackageColor = new Color32(50,250,50,255);
    Color32 noPackageColor = new Color32(255,255,255,255);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // If the thing we trigger is the package
        // then print package picked up to the console
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package to customer!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        

    }

}
