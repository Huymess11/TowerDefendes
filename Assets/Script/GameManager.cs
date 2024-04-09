using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPos;
    private int wave ;
    private int enermyAlive;
    private int enermyPerWave = 5;
    private int totalEnermy;
    public GameObject[] enermy;
    private float timeSpawn = 1.5f;
    public GameObject waveLevelBtn;
    private bool WaveStatus;
    private UI ui;
    private int totalCoin;
    public GameObject[] turret;
    private GameObject[] potpot;
    private GameObject[] turretgo;
    public bool canUpgrade;
    public GameObject LevelCompletePanel;
    public GameObject menuPanel;
    AudioManager audio;
    Heartbar h;
    public GameObject startTransition;
    public GameObject endTransition;
   // public GameObject enermyPlane;
    

    void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
        enermyAlive = enermyPerWave;
        ui = FindObjectOfType<UI>();
        WaveStatus = false;
        totalCoin = 150;
        potpot = GameObject.FindGameObjectsWithTag("Pot");
        h = FindObjectOfType<Heartbar>();
        startTransition.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        turretgo = GameObject.FindGameObjectsWithTag("Turret");
        ui.UpdateCoin("Coin:" + totalCoin);
        if (wave == 10 && h.curHealth()>0)
        {
            wave++;
            LevelCompletePanel.SetActive(true);
            PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
            audio.PlaySFX(audio.LevelComplete);
            return;
        }
        if (enermyAlive == 0)
        {
            WaveStatus = false;
            waveLevelBtn.SetActive(true);
            wave += 1;
            ui.UpdateWaveLevelText("Wave " + (wave + 1));
            totalEnermy = 0;
            enermyAlive = enermyPerWave;
        }
        if (WaveStatus == false) return;
        if (totalEnermy >= enermyPerWave) return;
        timeSpawn -= Time.deltaTime;
        if (timeSpawn <= 0)
        {
            SpawnEnermy();
            timeSpawn = 1.5f;
        }

           

    }
    
    private void SpawnEnermy()
    {
        totalEnermy += 1;
        int enerIndex = Random.Range(0, enermy.Length - 1);
        int enerEasy = Random.Range(0, 4);
        int enerHard = Random.Range(3, 6);
        if (wave == 0 || wave == 1 || wave == 2 || wave == 3) 
        { 
            Instantiate(enermy[enerEasy], startPos.position, Quaternion.identity); 
        }
        
        if (wave == 4 || wave == 5||wave == 6 || wave == 7 || wave == 8)
        {
            Instantiate(enermy[enerHard], startPos.position, Quaternion.identity);
        }
        if(wave == 9)
        {
            Instantiate(enermy[enerIndex], startPos.position, Quaternion.identity);
        }


    }
    public void setEnermyAlive(int value)
    {
        enermyAlive -= value;
    }
    private int getEnermyAlive()
    {
        return enermyAlive;
    }
    public void NextWave()
    {
        WaveStatus = true;
        waveLevelBtn.SetActive(false);
    }
    public void UpCoin(int value)
    {
        totalCoin += value;
    }
    public void DownCoin(int value)
    {
        if(value  <= totalCoin)
        {
           
            foreach (GameObject pot in potpot)
            {
                pot.GetComponent<pot>().SetCanBuild(true);
            }
            totalCoin -= value;
        }
        else
        {

            foreach (GameObject pot in potpot)
            {
                pot.GetComponent<pot>().SetCanBuild(false);
                pot.GetComponent<pot>().SetTurret();
            }
        }
    }
    public void CheckUpgradePrice(int value)
    {
        if(value <= totalCoin)
        {
            canUpgrade = true;
            totalCoin -= value;
        }
        else
        {
            canUpgrade = false;
        }
    }
    public bool GetCheckUpgradePrice()
    {
        return canUpgrade;
    }
    public void ChooseNormalTurret()
    {
       
        foreach ( GameObject pot in potpot)
        {
            pot.GetComponent<pot>().SetTurretandPrice(turret[0], 75);
        }

    }
    public void ChooseMetalTurret()
    {
        foreach (GameObject pot in potpot)
        {
            pot.GetComponent<pot>().SetTurretandPrice(turret[1], 120);
        }
    }
    public void ChooseRocket()
    {
        foreach (GameObject pot in potpot)
        {
            pot.GetComponent<pot>().SetTurretandPrice(turret[2], 200);
        }

    }
    public void Replay()
    {
        Time.timeScale = 1f;
        StartCoroutine(ReplayTransition());
    }
    public void ShowMenuPanal()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);

    }
    public void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(1));
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        StartCoroutine(NextLevelTransition());
    }
    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
   IEnumerator LevelTransition(int numScene)
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(numScene);
    }
    IEnumerator ReplayTransition()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator NextLevelTransition()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
