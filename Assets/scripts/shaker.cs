using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaker : MonoBehaviour
{

  [Range(0f , 2f)]
  public float intensity;
  Transform target;
  Vector3 initialPos;

  void Start(){
    target = GetComponent<Transform>();
    initialPos = target.localPosition;
  }

  float pendingShakeDuration = 0f;

  public void shake(float duration){
    if(duration > 0f){
      pendingShakeDuration += duration;
    }
  }

  bool isShaking = false;

  void Update(){
    if(pendingShakeDuration > 0 && !isShaking){
        StartCoroutine(DoShake());
    }
  }

  IEnumerator DoShake(){
    isShaking = true;

    var startTime = Time.realtimeSinceStartup;
    while(Time.realtimeSinceStartup < startTime + pendingShakeDuration){
      var randomPoint = new Vector3(Random.Range(12.8f, 13.2f)*intensity  , Random.Range(1.68f, 1.72f)*intensity , Random.Range(4.8f, 5.2f)*intensity );
      target.localPosition = randomPoint;
      yield return null;
    }


    pendingShakeDuration = 0f;
    transform.localPosition = initialPos;
    isShaking = false;
  }

}
