using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// move Speed - Bullet
	public float moveSpeed = 5f;
	// Rotate Variable
	float rot;
	// Update is called once per frame
	void FixedUpdate () {

		// get Bullet Position
		Vector3 pos = transform.position;
		// adding force / velocity
		Vector3 velocity = new Vector3( moveSpeed*Time.deltaTime ,0 , 0 );
		// actual mechanism
		pos += transform.rotation * velocity;
		// rot = transform.rotation.eulerAngles.z;
		transform.position = pos;

	}
}
