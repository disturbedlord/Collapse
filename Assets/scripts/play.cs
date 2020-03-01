using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class play : MonoBehaviour
{

    public Text bestScore;
    public GameObject startUi;

    public GameObject settingUi;
    public GameObject pad1 , pad2 , menu;
    public static bool playNow = false;
    public void moveToGameScene(){
        
        startUi.SetActive(false);
        resetVariables.play = true;
        pad1.SetActive(true);
        pad2.SetActive(true);
        menu.SetActive(true);
    }

    void Start(){
        // Time.timeScale = 0f;
        bestScore.text = PlayerPrefs.GetInt("best").ToString();
        if(playNow){
            resetVariables.play = false;
            playNow = true;
        }
    }

    private void Update()
    {
           if(resetVariables.play){
            startUi.SetActive(false);
            
            pad1.SetActive(true);
            pad2.SetActive(true);
            menu.SetActive(true);
        } 
    }

    public void openSettings(){
        settingUi.SetActive(true);
        moveToGameScene();
    }

}
