using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGameScript : MonoBehaviour
{

  public GameObject settings;
  public GameObject pauseUi ;

  public GameObject startUi;
  public void restartGame(){
   
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1;
    resetVariables.click_Restart = true;   
    Debug.Log(player.playerDead);
  }

  public void openSettings(){
    settings.SetActive(true);
    pauseUi.SetActive(false);
    startUi.SetActive(false);
  }

  public void backButton(){
    settings.SetActive(false);
    if(!resetVariables.play){
      startUi.SetActive(true);
    }else
      pauseUi.SetActive(true);
  }

  public void home(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1;
    resetVariables.play = false;
  }

}
