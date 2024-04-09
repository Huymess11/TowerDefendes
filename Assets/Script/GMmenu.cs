using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GMmenu : MonoBehaviour
{
    public GameObject startTransition;
    public GameObject endTransition;
    // Start is called before the first frame update
    private void Awake()
    {
        startTransition.SetActive(true);
    }
    public void Home()
    {
        StartCoroutine(LevelTransition(0));
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(1));
    }
    public void Level1()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(2));
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(3));
    }
    public void Level3()
    {
        Time.timeScale = 1f;
        StartCoroutine(LevelTransition(4));
    }
    public void DeletePlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Home();
    }
    IEnumerator LevelTransition(int numScene)
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(numScene);
    }
}
