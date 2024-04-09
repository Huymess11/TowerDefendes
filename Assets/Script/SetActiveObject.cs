using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void UnShow()
    {
        gameObject.SetActive(false);
    }
}
