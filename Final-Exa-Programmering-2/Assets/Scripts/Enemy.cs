using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy {

	[SerializeField] GameObject deathEffect;

	public void WasHit(float damage) {
		Die();
	}

	public void Die() {
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}
}