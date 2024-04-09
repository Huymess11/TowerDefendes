using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    private Color StartColor;
    public Color hoverColor;
    void Start()
    {
        StartColor = sr.color;
    }

    // Update is called once per frame
    public void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    public void OnMouseExit()
    {
        sr.color = StartColor;
    }
}
