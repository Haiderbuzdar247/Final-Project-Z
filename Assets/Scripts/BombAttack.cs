using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public List<GameObject> bombss;
    public static BombAttack instance;
    public GameObject bombs;
    Vector3 spawnpoint;
    public bool zone2;
    public Vector3 offset;
    public bool zone3;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zone2 )
        {
            InvokeRepeating(nameof(startbombing), 1, 2);
            zone2 = false;
        }
        if (!zone2 && zone3)
        {
            CancelInvoke();
        }
    }
    void startbombing()
    {
        
            spawnpoint = PlayerController.instance.transform.position + offset;
            GameObject go = Instantiate(bombs, spawnpoint, Quaternion.identity, transform.parent);
            bombss.Add(go);
        
        
        
    }
}
