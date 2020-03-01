using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour {

	// bullet Prefab
	public GameObject bullet;
	public float timebwShoots = 0.2f;
	float shootTime = 0f;
	bool bulletShot = false;
	Vector3 look = Vector3.zero;
	bool joystickReset = false;
	public GameObject bulletPos;
	// player rotation Speed
	public float rotationSpeed = 0.1f;
	float onGroundYPosition = 1.393928f;
	// check Grounded
	public float distToGround = 0.5f;
	public static bool onGround = false;

	// joyStick Variable
	public Joystick movementJoystick , viewJoystick;
	Vector3 move = Vector3.zero;
	Vector3 view = Vector3.zero;
	Vector3 prev_View = Vector3.zero;
	public static bool playerDead = false;
	// Defining Player Speed
	public float moveSpeed = 5.0f;
	private Rigidbody rb;
 	public GameObject gameOverUi;
  	public Text scoreText , bestScoreText;

	float y;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		onGround = false;
		view.z = 0;
	}

	void Update(){

		y = transform.position.y;
		if(y <= -5f){
			playerDead = true;
			gameOverUi.SetActive(true);
			scoreText.text = score.scoreVal.ToString();
			bestScoreText.text = "Best : "  + PlayerPrefs.GetInt("best" , 0).ToString();
			resetVariables.click_Restart = true;
		}

		// move Joystick
		move.x = movementJoystick.Horizontal;
		move.y = movementJoystick.Vertical;

		// view joyStick
		view.x = viewJoystick.Horizontal;
		view.y = viewJoystick.Vertical;

		// Check if view Joystick is UnTouched
		if(view.x == 0f && view.y == 0f && view.z == 0f){
			view = prev_View;
			joystickReset = false;
		}
		else {
			prev_View = view;
			joystickReset = true;
		}

		isGrounded();
		shootingPossible();
	}

	// Update is called once per frame
	void FixedUpdate () {

		// player Movement
		Vector3 movement = new Vector3(move.x , 0 , move.y) * moveSpeed * Time.deltaTime;
		rb.MovePosition(transform.position + movement);

		Vector3 lookDir = view;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg  ;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler (new Vector3 (0, -angle , 0)), Time.deltaTime * rotationSpeed);

	}

	void isGrounded(){
		// cast Line Below The player || Check Is Grounded
		onGround = Physics.Raycast(transform.position, Vector3.down, distToGround);
		
		if(onGround){
			rb.constraints = RigidbodyConstraints.FreezePositionY | 	RigidbodyConstraints.FreezeRotationZ | 	RigidbodyConstraints.FreezeRotationX | 	RigidbodyConstraints.FreezeRotationY;
		
		}
		else {
			rb.constraints = RigidbodyConstraints.None;
		}
	}

	void shootingPossible(){
		//  if user wants to shoot

		if(view.x >= 0.7f && view.y <= 0.7f || view.x <= 0.7f && view.y <= -0.7f){

				if(!bulletShot && joystickReset){
					bulletShot = true;
					shootBullet();

				}
		}
		else if(view.x <= 0.7f && view.y >= 0.7f || view.x <= -0.7f && view.y >=-0.7f){

			if(!bulletShot && joystickReset){
				bulletShot = true;
				shootBullet();

			}
		}

		shootTime += Time.deltaTime;

		if(shootTime > timebwShoots){
			bulletShot = false;
			shootTime = 0f;
		}


	}

	void shootBullet(){
			GameObject bulletClone = Instantiate(bullet , bulletPos.transform.position , transform.rotation);

			Destroy(bulletClone , 8f);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "piece"){
			Debug.Log("piece");
			Destroy(col.gameObject);
		}
	}

}
