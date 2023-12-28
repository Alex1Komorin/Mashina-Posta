using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadQuest : MonoBehaviour
{
    public GameObject what;
    static string h;
    public static string Desc
    {
        get { return h; }
        set { h = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(what.GetComponent<TextMeshProUGUI>().text);
        //what.GetComponent<TextMeshProUGUI>().text = Desc;
        //Debug.Log(what.GetComponent<TextMeshProUGUI>().text);
        //what.GetComponent<TextMeshProUGUI>().SetText(Desc);
        //Debug.Log(what.GetComponent<TextMeshProUGUI>().text);
    }
}
