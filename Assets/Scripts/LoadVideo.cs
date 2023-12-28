using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVideo : MonoBehaviour
{
    public void loadVideo(string filepath)
    {
        System.Diagnostics.Process.Start(filepath);
    }
}
