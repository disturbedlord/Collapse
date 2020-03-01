using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour
{

  public Rigidbody rb;
  void OnCollisionEnter(Collision col){

        rb.constraints = RigidbodyConstraints.FreezePositionY;

      // print("touching");

  }

  void OnCollisionExit(Collision col){


        rb.constraints = RigidbodyConstraints.None;

      // print("NOt_touching");

  }
}
