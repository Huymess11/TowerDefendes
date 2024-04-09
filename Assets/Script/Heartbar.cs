using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heartbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float maxhealth;
    private float curhealth;
    public GameObject gameoverPanel;
    AudioManager audio;
    private bool play = true;

    void Start()
    {
        curhealth = maxhealth;
        audio = FindObjectOfType<AudioManager>();
    }
    public void getCurhealth(float value)
    {
        curhealth -= value;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = curhealth / maxhealth;
        if (play == false) return;
        if(curhealth <= 0 )
        {
            play = true;
            gameoverPanel.SetActive(true);
            Time.timeScale = 0f;
            if(play == true) { 
                audio.PlaySFX(audio.LevelFailed);
                play = false;
            }
            
        }
    }
    public float curHealth()
    {
        return curhealth;
    }

}
