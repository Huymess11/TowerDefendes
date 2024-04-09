using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform target;
    private Enermy ener;
    private int Damage;
    private Turret hello;
    AudioManager audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }
    
    public void SetTarget(Transform m_target)
    {
        target = m_target;
    }
    public void SetDame(int value)
    {
        Damage = value;
    }
   
    // Update is called once per frame
  
    private void Update()
    {
        if (!target) return;
        Vector2 Dir = new Vector2(target.position.x - transform.position.x, target.position.y-transform.position.y);
        transform.up = Dir;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enermy>().TakeDame(Damage);
        }
    }
}
