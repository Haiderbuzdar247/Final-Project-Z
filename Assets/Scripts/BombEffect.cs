using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public float sphereRadius = 10f;
    public Collider[] hitcollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            Debug.Log("bomb hit ground");

            checkForDestruction();

        }
        //checkForDestruction();

    }

    void checkForDestruction()
    {
        hitcollider = Physics.OverlapSphere(transform.position, sphereRadius);
        foreach (Collider c in hitcollider)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                Debug.Log("bomb hit player");
                PlayerController.instance.takedamage();
                Destroy(gameObject);

            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position , sphereRadius);
    }
}
