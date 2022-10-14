using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text zone1Text;
    public TMP_Text zonenextText;
    public TMP_Text redZoneText;
    public TMP_Text zone3Text;
    public static PlayerMovement Instance;
    public CharacterController controller;
    public float speed = 6f;
    public float turnsmoothTime = 0.1f;
    float turnsmoothVelocity;
    public Transform camera;
    public bool chase;
    public bool chase1;
    public bool chase2;

    public bool enemypetrolstop;
    public bool enemypetrolstop1;
    public bool enemypetrolstop2;




    // Start is called before the first frame update
    private void Awake()
    {
        zone1Text.gameObject.SetActive(false);
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountDownTimer.instance.istimeUp)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetangele = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangele, ref turnsmoothVelocity, turnsmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 movdirection = Quaternion.Euler(0f, targetangele, 0f) * Vector3.forward;
                controller.Move(movdirection.normalized * speed * Time.deltaTime);

            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Zone1");
        
        if (other.gameObject.CompareTag("Zone1"))
        {
            CountDownTimer.instance.istimerStart = true;
            enemypetrolstop = true;
            Debug.Log("Entered Zone1");
            StartCoroutine(zone1Display());
            chase = true;
        }
        if (other.gameObject.CompareTag("Zone1.5"))
        {
            enemypetrolstop1 = true;
            StartCoroutine(watchBehind());
            chase1 = true;


        }

        if (other.gameObject.CompareTag("Zone2"))
        {
            StartCoroutine(redZone());
            enemypetrolstop2 = true;
            chase2 = true;
            BombAttack.instance.zone2 = true;
        }
        if (other.gameObject.CompareTag("Zone3"))
        {
            CountDownTimer.instance.istimerStart = false;
            StartCoroutine(Zone3Display());
            BombAttack.instance.zone2 = false;
            BombAttack.instance.zone3 = true;

        }


    }
    IEnumerator zone1Display()
    {
        zone1Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        zone1Text.gameObject.SetActive(false);
        Destroy(GameObject.Find("Zone1"));
    }

    IEnumerator watchBehind()
    {
        zonenextText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        zonenextText.gameObject.SetActive(false);
        Destroy(GameObject.Find("Zone1.5"));



    }
    IEnumerator redZone()
    {
        redZoneText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        redZoneText.gameObject.SetActive(false);
        Destroy(GameObject.Find("Zone2"));
    }
    IEnumerator Zone3Display()
    {
        zone3Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        zone3Text.gameObject.SetActive(false);
        Destroy(GameObject.Find("Zone3"));
    }
}
