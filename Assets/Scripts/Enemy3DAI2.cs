    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3DAI2 : MonoBehaviour
{
    public float speed;
    public GameObject enemyfire;
    public NavMeshAgent agent;
    public Transform player;
    bool firestart;
    public bool enemypetrolstop;
    bool isnextlocation;
    private void Awake()
    {
        player = GameObject.Find("Third Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance.enemypetrolstop2)
        {
            transform.LookAt(PlayerMovement.Instance.transform);
            Vector3 Distance = transform.position - PlayerMovement.Instance.transform.position;
            if (Distance.magnitude < 15f && firestart == false)
            {

                firestart = true;
                fireplayer();
                agent.SetDestination(transform.position);

            }
            if (PlayerMovement.Instance.chase2 && Distance.magnitude > 15f)
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
}
