using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text waveLevel;
    public Text coin;
    // Start is called before the first frame update
    public void UpdateCoin(string value)
    {
        coin.text = value;
    }
    public void UpdateWaveLevelText(string value)
    {
        waveLevel.text = value;
    }
}
