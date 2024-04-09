using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public Color color;
    private Color StartColor;
    private GameObject Turret;
    private int turretPrice;
    private GameManager gm;
    private GameObject TurretSet;
    private bool build = true;
    Collider2D potCol;
    AudioManager audio;
    void Start()
    {
        StartColor = sr.color;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        potCol = GetComponent<Collider2D>();    
        audio = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if(TurretSet  == null)
        {
            potCol.enabled = true;
        }
    }
    private void OnMouseEnter()
    {

            sr.color = color;

    }
    private void OnMouseExit()
    {
        sr.color = StartColor;
    }
    public void SetCanBuild(bool canBuild)
    {
        build = canBuild;
    }
    public void SetTurretandPrice(GameObject TurretValue, int TurretPrice)
    {
        this.Turret = TurretValue;
        turretPrice = TurretPrice;
        
    }
    public void SetTurret()
    {
        TurretSet = null;
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if (TurretSet != null)
        {
            return;
        }
        TurretSet = Turret;
        gm.DownCoin(turretPrice);
        if (build == false) return;
        GameObject newTurret = Instantiate(Turret, transform.position, Quaternion.identity);
        TurretSet = newTurret;
        newTurret.GetComponent<Turret>().Pot = this;
        potCol.enabled = false;
    }
}
