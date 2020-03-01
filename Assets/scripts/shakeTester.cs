using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeTester : MonoBehaviour
{

    public shaker shaker;
    public float duration = 1f;

    // Update is called once per frame
    void Update()
    {
        if(enemyTrigger.platform_shake_bullet){
          duration = 0.15f;
          shaker.shake(duration);
          enemyTrigger.platform_shake_bullet = false;
        }
        else if(enemyTrigger.platform_shake_player){
          duration = 0.20f;
          shaker.shake(duration);
          enemyTrigger.platform_shake_player = false;
        }
    }
}
