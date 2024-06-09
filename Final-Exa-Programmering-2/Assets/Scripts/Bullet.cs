using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Vector3 startPosition;

	private void Start() {
		startPosition = transform.position;
	}

	private void Update() {
		 if (Vector3.Distance(transform.position, startPosition) > CollisionWeapon.Instance.stats.maxDistance)
			DestroyImmediate(gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		other.gameObject.GetComponent<Enemy>().WasHit(CollisionWeapon.Instance.stats.damage);
		DestroyImmediate(gameObject);
	}
}