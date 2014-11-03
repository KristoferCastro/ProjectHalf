using System;
using UnityEngine;
using System.Collections;

public abstract class IPlayerState
{	
		protected PlayerController player;
		protected bool disabled;
		public IPlayerState (PlayerController player)
		{
			this.player = player;
		}
		
		public abstract void HandleInput();
		
		public abstract void Start();
		
		public abstract void FixedUpdate();
		
		public abstract void Update();
		
		public abstract void Disable();
		
		public abstract void Enable();
		
		public bool IsEnabled(){
			return !disabled;
		}
}
