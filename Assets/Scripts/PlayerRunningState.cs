//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
public class PlayerRunningState : IPlayerState
{
	
	public PlayerRunningState (Player player) : base(player)
	{
	}
		
	public override void HandleInput(){
		if (disabled) return;
		
		if (player.facingRight){
			//this.player.rigidbody2D.AddForce(new Vector2(player.speed, 0));
			player.rigidbody2D.velocity = new Vector2 (player.hMovement*player.speed, player.rigidbody2D.velocity.y);
		}
		
		else{
			//this.player.rigidbody2D.AddForce(new Vector2(-player.speed, 0));
			player.rigidbody2D.velocity = new Vector2 (player.hMovement*player.speed, player.rigidbody2D.velocity.y);
		}	
		
	} 
	
	public override void FixedUpdate(){
	}
	
	public override void Start(){
		
	}
	
	public override void Update(){
		HandleInput();
	}
	
	public override void Disable(){
		disabled = true;
	}
	
	public override void Enable(){
		disabled = false;
	}
}

