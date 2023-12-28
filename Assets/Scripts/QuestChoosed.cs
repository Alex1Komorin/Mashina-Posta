using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestChoosed : MonoBehaviour
{
    public GameObject desc;
    public void NextQuest(string namePath)
    {
        StartingQuest.Text = namePath;
        desc.GetComponent<Text>().text = Resources.Load < TextAsset >(namePath).ToString();
        switch (namePath)
        {
            case "TextForQuests/text_quest1":
            {
                HelpClose.Image = "ImageForHelp/quest1a";
                    AlgorithmQuest.SendMassiv = "0001 0";
                    AlgorithmQuest.RightMassiv = "11";
                break;
            }
            case "TextForQuests/text_quest2":
            {
                    HelpClose.Image = "ImageForHelp/quest2a";
                    AlgorithmQuest.SendMassiv = "111010101 0";
                    AlgorithmQuest.RightMassiv = "111111111";
                    break;
            }
            case "TextForQuests/text_quest3":
            {
                    HelpClose.Image = "ImageForHelp/quest3a";
                    AlgorithmQuest.SendMassiv = "0011100 0";
                    AlgorithmQuest.RightMassiv = "11111";
                    break;
            }
            case "TextForQuests/text_quest4":
            {
                    HelpClose.Image = "ImageForHelp/quest4a";
                    AlgorithmQuest.SendMassiv = "1111111 8";
                    AlgorithmQuest.RightMassiv = "1111011";
                    break;
            }
            case "TextForQuests/text_quest5":
            {
                    HelpClose.Image = "ImageForHelp/quest5a";
                    AlgorithmQuest.SendMassiv = "0 0";
                    AlgorithmQuest.RightMassiv = "10110111";
                    break;
            }
        }
    }
}
