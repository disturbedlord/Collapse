using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTrigger : MonoBehaviour
{

    private int bullet_Touched_Count = 1;
    public static bool remove_Platform = false;
    public static bool platform_shake_bullet = false;
    public static bool platform_shake_player = false;
    // check if bullet touched the enemy_Clone
    void OnTriggerEnter(Collider col){
      // Debug.Log("Touched by Bullet");
        if(col.gameObject.tag == "bullet"){
          platform_shake_bullet = true;
          if(bullet_Touched_Count < 3){

              bullet_Touched_Count ++;
              Destroy(col.gameObject);
          }else {


              Destroy(transform.parent.gameObject);
              // reduce Number of enemies

              enemyManager.enemy_count--;
          }
        }
        else if(col.gameObject.tag == "player"){
            // destroy enemy gameoObject
            platform_shake_player = true;
             remove_Platform = true;
            Destroy(transform.parent.gameObject);

            // move to platformManager sCRIPT
           
        }
    }
}
