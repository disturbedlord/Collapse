using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetVariables : MonoBehaviour
{
    public GameObject startUi;
    public static bool click_Restart = false;
    public static bool play = false;
    public GameObject pad1 , pad2;
    public Text padSizeText;
    private void Start(){
        pad1.transform.localScale = new Vector3(    1f + PlayerPrefs.GetInt("padSize" , 1)/10f, 1f + PlayerPrefs.GetInt("padSize" , 1)/10f, 1f + PlayerPrefs.GetInt("padSize" , 1)/10f);
        pad2.transform.localScale = new Vector3(1f + PlayerPrefs.GetInt("padSize", 1)/10f,1f + PlayerPrefs.GetInt("padSize" , 1)/10f, 1f + PlayerPrefs.GetInt("padSize" , 1)/10f);
        padSizeText.text = PlayerPrefs.GetInt("padSize" , 1).ToString();
        
    }
    void Update(){
        if(click_Restart){
            resetValues();
            Start();
            
            click_Restart = false;
        }
        
    }

    void resetValues(){
        enemyManager.enemy_count = 0;
        enemyTrigger.remove_Platform = false;
        enemyTrigger.platform_shake_bullet = false;
        enemyTrigger.platform_shake_player = false;
        platformManager.lastPlatform = false;
        player.onGround = false;
        // platformManager.count = 0;
        player.playerDead = false;
  }
}
