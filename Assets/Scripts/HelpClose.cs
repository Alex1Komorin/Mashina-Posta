using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpClose : MonoBehaviour
{
    GameObject background;
    GameObject button;
    GameObject image;
    GameObject backto;
    GameObject b_clue;
    GameObject b_start;
    GameObject b_desc;
    GameObject b_check;
    GameObject scroll;
    AlgorithmQuest algorithmQuest;
    static string imageq;
    public static string Image
    {
        get { return imageq; }
        set { imageq = value; }
    }

    void Start()
    {
        //algorithmQuest = gameObject.AddComponent<AlgorithmQuest>();
        //algorithmQuest.CloseMessagBox();
        background = GameObject.Find("MessageHelp");
        button = GameObject.Find("ButtonHelp");
        image = GameObject.Find("ImageHelp");
        backto = GameObject.Find("BackTo");
        b_clue = GameObject.Find("ButtonClue");
        b_start = GameObject.Find("ButtonStart");
        b_desc = GameObject.Find("ButtonDesc");
        b_check = GameObject.Find("ButtonCheck");
        scroll = GameObject.Find("Scroll View");
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(Image);
        //image.GetComponent<SpriteRenderer>().transform.localScale = new Vector3 (0.15f, 0.3f, 1);
        background.SetActive(false);
        button.SetActive(false);
        image.SetActive(false);
    }
    public void Input()
    {
        backto.SetActive(false);
        b_clue.SetActive(false);
        b_start.SetActive(false);
        b_desc.SetActive(false);
        b_check.SetActive(false);
        //scroll.SetActive(false);
        background.SetActive(true);
        button.SetActive(true);
        image.SetActive(true);
    }
    public void Output()
    {
        backto.SetActive(true);
        b_clue.SetActive(true);
        b_start.SetActive(true);
        b_desc.SetActive(true);
        b_check.SetActive(true);
        //scroll.SetActive(true);
        background.SetActive(false);
        button.SetActive(false);
        image.SetActive(false);
    }
}
