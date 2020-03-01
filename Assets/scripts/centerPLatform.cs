using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerPLatform : MonoBehaviour
{
  public Rigidbody rb;

  void Update(){

    if(player.onGround && !platformManager.lastPlatform){
      rb.constraints = RigidbodyConstraints.FreezePositionX |	RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | 	RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ ;
    }
    else {
      rb.constraints = RigidbodyConstraints.None;
    }
  }
}
