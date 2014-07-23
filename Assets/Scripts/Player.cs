using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// these variables should probably be in their respective concrete state classes
	// but to see it in unity interface, we put it here.
	public float speed;
	public bool facingRight = true;
	public float jumpForce = 475f; // how high the player jumps
	public float dashForce = 1000f;
	public bool grounded = true;
	public Transform groundCheck;
	public float hMovement;	
	public LayerMask whatIsGround;
	Animator anim;
	
	// two separate state
	public IPlayerState[] movementState = new IPlayerState[3];
	IPlayerState dashingState;
	IPlayerState jumpingState;
	
	//IPlayerState weaponState; 
	
	public static readonly int RUNNING = 0;
	public static readonly int DASHING = 1;
	public static readonly int JUMPING = 2;
	
	bool blocking = false;
	// Use this for initialization
	void Start () {
		initializeVariables();
		anim = GetComponent<Animator>();
	}
	
	void initializeVariables(){
		speed = 5;
		
		//weaponState = new PlayerShootingState(this);
		movementState[Player.RUNNING] = new PlayerRunningState(this);
		movementState[Player.DASHING] =  new PlayerDashState(this);
		movementState[Player.JUMPING] = new PlayerJumpingState(this);
	}
	
	void FixedUpdate(){
		UpdateGroundedCheck();
		
		foreach (IPlayerState ps in movementState){
			ps.FixedUpdate();
		}
		
		//weaponState.FixedUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		FlipCheck();
		anim.SetFloat ("speed", Mathf.Abs(hMovement));
		anim.SetBool ("blocking", blocking);
		//ManageStateTransitions();
		//weaponState.Update();
		
		foreach (IPlayerState ps in movementState){
			ps.Update();
		}		
		
		if ((!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) && Input.GetKey(KeyCode.DownArrow)){
			blocking = true;
		}else
			blocking = false;
	}
	
	void ChangeWeaponState(IPlayerState state){
		//weaponState = state;
	}
	
	void ChangeMovementState(IPlayerState state){
		//movementState = state;
	}
	
	
	void UpdateGroundedCheck(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);
	}
	
	bool TryingToMoveLeft (){
		return hMovement < 0;
	}
	
	bool TryingToMoveRight (){
		
		return hMovement > 0;
	}
	
	void FlipCheck(){
		hMovement = Input.GetAxis ("Horizontal");
		if (anim.GetBool("shooting close"))
			hMovement = 0;
		if ( (TryingToMoveRight () && !facingRight)
		    || (TryingToMoveLeft () && facingRight) ){
			Flip ();
		}
	}
	
	void Flip(){
		facingRight = !facingRight;
		// rotate 180 degrees
		this.transform.RotateAround (Vector3.up, Mathf.PI);
	}
	
	private bool OffGround(){
		return rigidbody2D.velocity.y > 0;
	}
}
