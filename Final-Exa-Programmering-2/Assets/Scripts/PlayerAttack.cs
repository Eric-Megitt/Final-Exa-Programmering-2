using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] MeleeWeapon meleeWeapon;
	[SerializeField] RaycastWeapon raycastWeapon;
	[SerializeField] CollisionWeapon collisionWeapon;

	Movement playerMovement;

	private void Awake() {
		playerMovement = GetComponent<Movement>();
	}

	private void OnEnable() {
		playerMovement.playerInput.Player.MeleeAttack.canceled += MeleeAttack;
		playerMovement.playerInput.Player.MeleeAttack.performed += PrepareMeleeAttack;
		playerMovement.playerInput.Player.RaycastAttack.performed += ShootRaycastWeapon;
		playerMovement.playerInput.Player.CollisionAttack.performed += ShootCollisionWeapon;

		playerMovement.playerInput.Player.MeleeAttack.Enable();
		playerMovement.playerInput.Player.RaycastAttack.Enable();
		playerMovement.playerInput.Player.CollisionAttack.Enable();
	}
	private void OnDisable() {
		playerMovement.playerInput.Player.MeleeAttack.Disable();
		playerMovement.playerInput.Player.RaycastAttack.Disable();
		playerMovement.playerInput.Player.CollisionAttack.Disable();
	}

	void MeleeAttack(InputAction.CallbackContext callbackContext) {
		meleeWeapon.Attack();
	}

	void PrepareMeleeAttack(InputAction.CallbackContext callbackContext) {
		meleeWeapon.PrepareMeleeAttack();
	}

	void ShootRaycastWeapon(InputAction.CallbackContext callbackContext) {
		raycastWeapon.Shoot();
		//print("Bang Bang (My Baby Shot Me Down)");
	}
	void ShootCollisionWeapon(InputAction.CallbackContext callbackContext) {
		collisionWeapon.Shoot();
	}

}