using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
  public Text score_text;
  float t;
  public static bool ranOnce = false;
  public float timeDelay = 0.2f;
  
  public static int scoreVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
        scoreVal = 0;
        score_text.text = PlayerPrefs.GetInt("best" , 0).ToString();
        ranOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = scoreVal.ToString();
        t += Time.deltaTime;
        if(t > timeDelay && !player.playerDead && resetVariables.play){
          scoreVal += 1;
          t = 0f;
        }

        if(scoreVal > PlayerPrefs.GetInt("best" , 0 )){
          PlayerPrefs.SetInt("best" , scoreVal);
        }
    }
}
