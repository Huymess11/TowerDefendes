using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update
    Waypoint waypoint;
    public float speed;
    private int index = 0;
    private HealthEnermy he;
    private Turret turret;
    public float MaxHealth;
    private GameManager gm;
    private Heartbar hb;
    public GameObject boom;
    AudioManager audio;
    private float curhealth;
    public Slider slider;
    public GameObject DameTxt;
    public TMP_Text dameTxt;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        hb = FindObjectOfType<Heartbar>();
        waypoint = GameObject.FindGameObjectWithTag("pos").GetComponent<Waypoint>();
        audio = FindObjectOfType<AudioManager>();
        curhealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = curhealth / MaxHealth;
        transform.position = Vector2.MoveTowards(transform.position, waypoint.pos[index].position, speed * Time.deltaTime);
        Vector2 direction = transform.position - waypoint.pos[index].position;
        transform.right = -direction;
        if (Vector2.Distance(transform.position, waypoint.pos[index].position) < 0.1f)
        {
            if (index < waypoint.pos.Length - 1)
            {
                index++;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (curhealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(boom,transform.position, Quaternion.identity);
            gm.UpCoin(10);
            gm.setEnermyAlive(1);
        }
    }
    public void TakeDame(int value)
    {
        dameTxt.text = value.ToString();
        Instantiate(DameTxt, transform.position, Quaternion.identity);
        curhealth -= value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            hb.getCurhealth(20);
            gm.setEnermyAlive(1);
            audio.PlaySFX(audio.TowerTakeDame);
        }
        if (collision.CompareTag("Rocket"))
        {
            audio.PlaySFX(audio.Rocket);
        }
        if(collision.CompareTag("NormalBullet")|| collision.CompareTag("MetalBullet"))
        {
            audio.PlaySFX(audio.Bullet);
        }
    }
} 
