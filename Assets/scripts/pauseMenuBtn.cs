using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuBtn : MonoBehaviour
{
  public GameObject pauseUi;
  

    public void pauseGame(){

        Time.timeScale = 0;
        pauseUi.SetActive(true);

    }
}
