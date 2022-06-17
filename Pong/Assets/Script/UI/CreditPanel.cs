using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel : MonoBehaviour
{
    public void ClosePanel()
    {
        Destroy(gameObject);
    }

    public void OpenUrl(string _url)
    {
        Application.OpenURL(_url);
    }
}