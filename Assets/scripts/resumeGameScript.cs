using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeGameScript : MonoBehaviour
{
    public GameObject pauseUi;

    public void resumeGame(){
      pauseUi.SetActive(false);
      Time.timeScale = 1;
    }
}
