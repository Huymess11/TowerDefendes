using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyplane : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tower;
    public float speed;
    private Heartbar hb;
    private GameManager gm;
    private AudioManager audio;
    public int maxhealth;
    void Start()
    {
        hb = FindObjectOfType<Heartbar>();
        gm = FindObjectOfType<GameManager>();
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = tower.position - transform.position;
        transform.right = dir;
        transform.position = Vector2.MoveTowards(transform.position, tower.position, speed * Time.deltaTime);

        if (maxhealth <= 0)
        {
            Destroy(gameObject);
            gm.UpCoin(10);
            gm.setEnermyAlive(1);
        }
    }
    public void TakeDame(int value)
    {
        maxhealth -= value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Tower"))
        {
            hb.getCurhealth(20);
            gm.setEnermyAlive(1);
            audio.PlaySFX(audio.TowerTakeDame);
        }
    }
}
