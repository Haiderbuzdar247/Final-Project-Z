using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public static Target instance;
    public TMP_Text healthtext;
    public float health = 50;
    public ParticleSystem explosions;

    // Start is called before the first frame update
    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        healthtext.text = health.ToString();    
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takedamage(float amount)
    {
        health -= amount;
        healthtext.text = health.ToString();

        if (health <= 0)
        {
            Instantiate(explosions, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
