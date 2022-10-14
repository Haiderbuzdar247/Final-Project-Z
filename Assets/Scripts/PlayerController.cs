using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject playerGun;
    public TMP_Text laserAmmo;
    public int ammo = 0;
    public static PlayerController instance;
    public float health;
    public float maxhealth = 100f;
    public Slider healthbar;
    public float damage = 10f;
    public float range = 100f;
    Ray ray;
    RaycastHit hit;
    public Camera camera;
    public Transform gun;
    public LineRenderer lineRend;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        laserAmmo.text = "Laser Ammo: " + ammo.ToString();

        healthbar.maxValue = maxhealth;
        healthbar.minValue = 0;
        health = 60;

    }

    // Update is called once per frame
    void Update()
    {
        laserAmmo.text = "Laser Ammo: " + ammo.ToString();
        healthbar.value = health;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            if (Input.GetButtonDown("Fire1") && !CountDownTimer.instance.istimeUp)
            {
                if (ammo > 0 && Time.timeScale!=0)
                {
                    GameManager.instance.gameplay.PlayOneShot(GameManager.instance.fire);
                    ammo -= 1;
                    lineRend.enabled = true;
                    lineRend.SetPosition(0, gun.transform.position);
                    lineRend.SetPosition(1, hit.point);
                    if (hit.transform.name == "Enemy1" || hit.transform.name == "Enemy2" || hit.transform.name == "Enemy3" || hit.transform.name == "Enemy4" || hit.transform.name == "Enemy5")
                    {
                        Target target = GameObject.Find(hit.transform.name).GetComponent<Target>();
                        Debug.Log("enemyhit");
                        target.takedamage(damage);
                    }
                }
               

            }

        }
        else
        {
            Debug.Log("LineRendDisable");
            lineRend.enabled = false;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            playerGun.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("playerhit");
            takedamage();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ammo"))
        {
            ammo = 25;
            laserAmmo.text = "Laser Ammo: " + ammo.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Health"))
        {
            health = maxhealth;
            Destroy(other.gameObject);
        }

    }
    public void takedamage()
    {
        health -= 10f;
        GameManager.instance.gameplay.PlayOneShot(GameManager.instance.hit);

        if (health <= 0)
        {
            CountDownTimer.instance.gameOverText.gameObject.SetActive(true);
            CountDownTimer.instance.restart.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void shootfire()
    {


    }
}
