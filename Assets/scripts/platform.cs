using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Rigidbody rb;

    void Start(){
      rb.isKinematic = true;
    }
    // void Update(){
    //
    //   if(player.onGround){
    //     rb.constraints = RigidbodyConstraints.FreezePositionX |	RigidbodyConstraints.FreezePositionZ | 	RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ ;
    //   }
    //   else {
    //     rb.constraints = RigidbodyConstraints.None;
    //   }
    // }
}
