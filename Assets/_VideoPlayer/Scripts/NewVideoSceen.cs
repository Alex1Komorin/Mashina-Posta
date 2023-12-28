using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceen : MonoBehaviour
{
    public GameObject button;

    public int sceen;
    public void LoadLastSceen()
    {
        if (button.CompareTag("Load"))
        {
            SceneManager.LoadScene(sceen);
        }
    }

    public void OnMouseDown()
    {
        LoadLastSceen();
    }
}
