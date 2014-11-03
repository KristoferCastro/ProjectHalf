using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private Transform player;
	
	// hold the x and y position of left and right wall
	private float minLeft;
	private float minRight;
	
	private float cameraWidth;
	private float cameraHeight;
	
	public float dampTime = 0.2f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Use this for initialization
	void Start () {
				
		player = GameObject.Find("Emmalyn").transform;
		minLeft = GameObject.Find ("LeftWall").transform.position.x;
		minRight = GameObject.Find ("RightWall").transform.position.x;
		
		cameraHeight = 2f * Camera.main.orthographicSize;
		cameraWidth = cameraHeight * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 playerPosition = player.position;
		
		// Make sure the camera doesn't reveal stuff outside the level
		if ((playerPosition.x) - cameraWidth/2 <= minLeft) 
			return;
		if ((playerPosition.x) + cameraWidth/2 >= minRight)
			return;
		
		playerPosition.y = transform.position.y;
		
		Vector3 point = Camera.main.WorldToViewportPoint(playerPosition);
		Vector3 delta = playerPosition - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);		
	}
}
