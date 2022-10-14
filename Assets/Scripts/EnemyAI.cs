using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public float health = 50;
    public Transform[] walkpoints;
    int current = 0;
    public float speed;
    public GameObject enemyfire;
    public NavMeshAgent agent;
    public Transform player;

    bool firestart;
    
    bool isnextlocation;

    private void Awake()
    {
        player = GameObject.Find("Third Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //if (!enemypetrolstop)
        //{
        //    if (transform.position != walkpoints[current].position )
        //    {
        //        Vector3 pos = Vector2.MoveTowards(transform.position, walkpoints[current].position, speed * Time.deltaTime);
        //        GetComponent<Rigidbody>().MovePosition(pos);
        //        Debug.Log("moving");
                
        //    }
        //   else
        //    {
        //        Debug.Log("next location");
        //        current = (current + 1) % walkpoints.Length;
        //    }

        //}
        if (PlayerMovement.Instance.enemypetrolstop)
        {
            transform.LookAt(PlayerMovement.Instance.transform);
            Vector3 Distance = transform.position - PlayerMovement.Instance.transform.position;
            if (Distance.magnitude < 15f && firestart == false)
            {

                firestart = true;
                fireplayer();
                agent.SetDestination(transform.position);

            }
            if (PlayerMovement.Instance.chase && Distance.magnitude > 15f)
            {
                Chaseplayer();
                firestart = false;
            }
            if (!PlayerMovement.Instance.chase)
            {
                agent.SetDestination(transform.position);
            }
        }

        


    }
    
    void fireplayer()
    {
        if (firestart)
        {
            Debug.Log("Firestart");
            InvokeRepeating("firerepeat", 1, 2);

        }

    }
    void firerepeat()
    {
        if (firestart)
        {
            Rigidbody fire = Instantiate(enemyfire, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            fire.AddForce(transform.forward * 32f, ForceMode.Impulse);
            fire.AddForce(transform.up * 4f, ForceMode.Impulse);
        }
        if (!firestart)
        {
            CancelInvoke();
        }

    }

    void Chaseplayer()
    {
        agent.SetDestination(PlayerMovement.Instance.transform.position);
        transform.LookAt(player);

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("rayhit enemy");
    //    health -= 10;
    //}
   

}
