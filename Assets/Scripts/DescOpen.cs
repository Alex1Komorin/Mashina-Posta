using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescOpen : MonoBehaviour
{
    GameObject background;
    GameObject button;
    GameObject text;
    GameObject backto;
    GameObject b_clue;
    GameObject b_start;
    GameObject b_desc;
    GameObject b_check;
    GameObject scroll;

    void Start()
    {
        background = GameObject.Find("MessageDesc");
        button = GameObject.Find("DescClose");
        text = GameObject.Find("DescriptionForQuest");
        backto = GameObject.Find("BackTo");
        b_clue = GameObject.Find("ButtonClue");
        b_start = GameObject.Find("ButtonStart");
        b_desc = GameObject.Find("ButtonDesc");
        b_check = GameObject.Find("ButtonCheck");
        scroll = GameObject.Find("Scroll View");
        text.GetComponent<Text>().text = Resources.Load<TextAsset>(StartingQuest.Text).ToString();
        background.SetActive(false);
        button.SetActive(false);
        text.SetActive(false);
    }
    public void Input()
    {
        backto.SetActive(false);
        b_clue.SetActive(false);
        b_start.SetActive(false);
        b_desc.SetActive(false);
        b_check.SetActive(false);
        scroll.SetActive(false);
        background.SetActive(true);
        button.SetActive(true);
        text.SetActive(true);
    }
    public void Output()
    {
        backto.SetActive(true);
        b_clue.SetActive(true);
        b_start.SetActive(true);
        b_desc.SetActive(true);
        b_check.SetActive(true);
        scroll.SetActive(true);
        background.SetActive(false);
        button.SetActive(false);
        text.SetActive(false);
    }
}
