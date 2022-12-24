using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay;
    [SerializeField] Color32 hasPackageColor = new Color32(255,255,255,255);
    [SerializeField] Color32 noPackageColor = new Color32(0,0,0,255);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && hasPackage == false)
        {           
            hasPackage = true;
            this.spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
           
        }

        if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package delivered.");
            this.spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
