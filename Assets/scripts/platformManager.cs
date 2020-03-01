using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{

    public GameObject[] platform;
    Rigidbody rb;

    int[] cornerPlatforms = {1 , 3 , 7 , 9};
    int[] sidePlatforms = {2 , 4 , 6 , 8};
    int centerPlatform = 5;
    public static bool lastPlatform = false;
    public int count = 0;

    // Update is called once per frame
    void Update(){

        if(enemyTrigger.remove_Platform){

          int p = selectPlatform();

          // get RigidBody Component of the platform

          if(p-1 == 4){

            rb = platform[p-1].GetComponent<Rigidbody>();

            lastPlatform = true;

          }else {

            rb = platform[p-1].GetComponent<Rigidbody>();

          }
          // drop the platform
          rb.isKinematic = false;
          rb.useGravity = true;
          // prevent the fall of other platform
          enemyTrigger.remove_Platform = false;
        }
    }

    int selectPlatform(){
      int platformToRemove;
      if(count < 4){
        platformToRemove = cornerPlatforms[count];
        count++;
      }else if(count > 3 && count < 8){
        platformToRemove = sidePlatforms[count - 4];
        count++;
      }else {
        platformToRemove = centerPlatform;
        count++;
      }
        return platformToRemove;
    }
}
