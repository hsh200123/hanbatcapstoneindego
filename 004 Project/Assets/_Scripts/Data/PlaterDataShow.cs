using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterDataShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.label);
        myStyle.fontSize = 50;
        GUI.Label(new Rect(200,130,Screen.width*0.5f,Screen.height*0.25f),"PlayerType : " + PlayerDataAnalyze.playerType,myStyle);
        myStyle.fontSize = 30;
        GUI.Label(new Rect(200,180,Screen.width*0.5f,Screen.height*0.25f),"parryratio : " + PlayerDataAnalyze.parryRatio.ToString("F2"),myStyle);
        GUI.Label(new Rect(200,210,Screen.width*0.5f,Screen.height*0.25f),"runratio : " + PlayerDataAnalyze.runRatio.ToString("F2"),myStyle);
        GUI.Label(new Rect(200,240,Screen.width*0.5f,Screen.height*0.25f),"dashratio : " + PlayerDataAnalyze.dashRatio.ToString("F2"),myStyle);
    }
}
