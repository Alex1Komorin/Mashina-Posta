using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartingQuest : MonoBehaviour
{
    public GameObject desc;
    public GameObject help;
    GameObject quest_text;
    static string text;
    //static string image;
    public static string Text
    {
        get { return text; }
        set { text = value; }
    }
    //public static string Image
    //{
    //    get { return image; }
    //    set { image = value; }
    //}
    public void QuestStart()
    {
        desc.GetComponent<Text>().text = Resources.Load<TextAsset>(Text).ToString();
        //Debug.Log(help.GetComponent<SpriteRenderer>().sprite);
        //help.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Image);
        //Debug.Log(help.GetComponent<SpriteRenderer>().sprite);
    }

    private void Start()
    {
        quest_text = GameObject.Find("TextForDescription");
        quest_text.GetComponent<Text>().text = Resources.Load<TextAsset>(Text).ToString();
    }
}
