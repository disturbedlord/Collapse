using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    // player Transform
    private GameObject player;
    Vector3 playerPos ;
    float force = 50f;
    // moveSpeed of the enemy GameObject
    public float moveSpeed = 5f;

    void Start()
    {
          player = GameObject.FindWithTag("gunPosition");
          playerPos = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(resetVariables.play){
        // getting the player GameObject
        player = GameObject.FindWithTag("player");
        playerPos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos , moveSpeed * Time.deltaTime);
      }
    }

    // check if bullet touched the enemy_Clone
    void OnTriggerEnter(Collider col){
      if (col.gameObject.tag == "enemy"){
      // Calculate Angle Between the collision point and the player
      Vector3 dir = col.transform.position -  transform.position;
      // We then get the opposite (-Vector3) and normalize it
      dir = -dir.normalized;
      // And finally we add force in the direction of dir and multiply it by force.
      // This will push back the player
      GetComponent<Rigidbody>().AddForce(dir*force);
      }
    }
}
