using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : Singleton<Movement> {
	//Cached references
	Rigidbody _rigidbody;
	
	//Serialized Fields
	[SerializeField] Transform spriteTransform;
	[SerializeField] float movementSpeed;
	[SerializeField] Settings settingsFile;
	float rotationCoefficient;
	[Header("Jump")] 
	[SerializeField, Range(0,1)] float jumpDownSize;
	[Header("Inspector")]
	[SerializeField] bool debugging;
	
	#region Input
	public PlayerInput playerInput;
	InputAction movementInput;
	InputAction lookInput;


#pragma warning disable CS0108, CS0114
	void Awake() {
#pragma warning restore CS0108, CS0114
		base.Awake();
		
		playerInput = new PlayerInput();
	}

	void OnEnable()
	{
		movementInput = playerInput.Player.Movement;
		movementInput.Enable();
		lookInput = playerInput.Player.Look;
		lookInput.Enable();
		playerInput.Player.Jump.Enable();

		playerInput.Player.Jump.performed += JumpPressed;
		playerInput.Player.Jump.canceled += JumpReleased;

	}

	void OnDisable(){
		lookInput.Disable();
		movementInput.Disable();
		playerInput.Player.Jump.Disable();
	}
	#endregion Input
	
	void Start() {
		_rigidbody = GetComponent<Rigidbody>();

		rotationCoefficient = settingsFile.rotationCoefficient;
	}

	void Update() {
		RotatePlayer();
		MovePlayer();
		
	}

	void MovePlayer() {
		Vector2 inputVector = movementInput.ReadValue<Vector2>();
		
		_rigidbody.velocity = movementSpeed * (inputVector.y * -TransformBackwards);
	}
	
	void RotatePlayer() {
		float inputFloat = lookInput.ReadValue<float>();

		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, -(rotationCoefficient * -inputFloat), 0));
	}

	void JumpPressed(InputAction.CallbackContext callbackContext) {
		spriteTransform.localScale -= new Vector3(jumpDownSize, 0, 0);
	}

	void JumpReleased(InputAction.CallbackContext callbackContext) {
		spriteTransform.localScale += new Vector3(jumpDownSize, 0, 0);
		_rigidbody.AddForce(0, 200, 0, ForceMode.Impulse);
	}

	
	
	public Vector3 TransformBackwards => new(transform.right.z, 0, -transform.right.x);
	
	#region Gizmos
	void OnDrawGizmosSelected() {
		if (!debugging) return;
		
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(transform.position, (transform.position + transform.right));
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, (transform.position + TransformBackwards));
	}
	#endregion Gizmos
}
