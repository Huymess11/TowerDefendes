using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackRadius = 3f;
    [SerializeField] private LayerMask mask;
    private Transform target;
    private bullet bulet;
    [SerializeField] private GameObject bull;
    public Transform shootPoint;
    public float m_coolingAttack;
    public int TurretDamage;
    private float coolingAttack;
    private GameManager gm;
    public GameObject upGradPanel;
    public GameObject[] potpot;
    public int UpgradePrice = 50;
    public Text upgradeText;
    public GameObject attackViewRadius;
    AudioManager audio;
    public GameObject attackPanel;
    public Text attackcur;
    public pot Pot { get; set; }

    void Start()
    {
        potpot = GameObject.FindGameObjectsWithTag("Pot");
        gm = FindObjectOfType<GameManager>();
      coolingAttack = m_coolingAttack;
        audio = FindObjectOfType<AudioManager>();
        
    }
    private void SetupgradText(string value)
    {
        upgradeText.text = value;
    }
    private void SetAttackText(string value)
    {
        attackcur.text = value;
    }
    // Update is called once per frame
    void Update()
    {
        SetAttackText("ATK: " + TurretDamage);
        SetupgradText("Upgrade(" + UpgradePrice + ")");
        if (target == null)
        {
            FindTarget();
            return;
        }
        followTarget();
        if (!CheckEnermyInAttackArea())
        {
            target = null;
        }
        else
        {
            coolingAttack -= Time.deltaTime;
            if(coolingAttack <= 0)
            {
                Shoot();
                coolingAttack = m_coolingAttack  ;
            }

        }
        attackPanel.transform.up = Vector2.up;
        upGradPanel.transform.up = Vector2.up;
    }
    public void UpDame()
    {
        gm.CheckUpgradePrice(UpgradePrice);
        if (gm.GetCheckUpgradePrice() == true)
        {
            audio.PlaySFX(audio.UPgrade);
            this.TurretDamage += 20;
            UpgradePrice += 30;
        }
        
    }
    public void sellNormalTurret()
    {
        audio.PlaySFX(audio.Coin);
        gm.UpCoin(75);
        Pot.SetTurret();
        Destroy(gameObject);
    }
    public void sellMetalTurret()
    {
        audio.PlaySFX(audio.Coin);
        gm.UpCoin(120);
        Pot.SetTurret();
        Destroy(gameObject);

    }
    public void sellRockket()
    {
        audio.PlaySFX(audio.Coin);
        gm.UpCoin(200);
        Pot.SetTurret();
        Destroy(gameObject);
    }
    public int getDame()
    {
        return TurretDamage;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRadius, transform.position,0f,mask);
        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    
    private bool CheckEnermyInAttackArea()
    {
        return Vector2.Distance(transform.position, target.position) <= attackRadius;
    }
    private void followTarget()
    {
        Vector2 dir = target.position - transform.position;
        transform.up = dir;
    }
    private void Shoot()
    {
        
        GameObject bulletObj = Instantiate(bull, shootPoint.position, Quaternion.identity);
        bulet = bulletObj.GetComponent<bullet>();
        bulet.SetTarget(target);
        bulet.SetDame(TurretDamage);
        
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, attackRadius);
        

    }
#endif
    private void OnMouseDown()
    {
        upGradPanel.SetActive(true);
        
    }
    private void OnMouseExit()
    {
        upGradPanel.SetActive(false);
        attackViewRadius.SetActive(false);
        attackPanel.SetActive(false);
    }
    private void OnMouseEnter()
    {
        attackPanel.SetActive(true);
        attackViewRadius.SetActive(true);
    }
}
