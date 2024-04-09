using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public AudioSource SFX;
    public AudioClip LevelComplete;
    public AudioClip LevelFailed;
    public AudioClip Bullet;
    public AudioClip Rocket;
    public AudioClip UPgrade;
    public AudioClip Coin;
    public AudioClip TowerTakeDame;


    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip,0.7f);
        SFX.loop = false;
    }

}
