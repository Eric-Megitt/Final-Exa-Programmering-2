using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {
	public MeleeWeaponStats stats;
	BoxCollider boxCollider;
	MeshRenderer meshRenderer;

	[Header("SwrodSwing")]
	float originalRotation;
	[SerializeField] Transform pivotPoint;
	[SerializeField] float secondDelayAfterSwordSwing = .25f;

	[Header("Debugging")]
	[SerializeField] bool debugHitbox;
	[SerializeField] GameObject hitboxVisual;

	private void OnValidate() {
		ShowHitBox();
	}

	private void Start() {
		boxCollider = GetComponent<BoxCollider>();
		meshRenderer = GetComponent<MeshRenderer>();
		ShowHitBox();

		if (pivotPoint == null) {
			pivotPoint = transform;
		} 
	}

	public void Attack() {
		boxCollider.enabled = true;
		StartCoroutine(SwingWeapon());
	}

	IEnumerator SwingWeapon() {
		originalRotation = transform.localRotation.eulerAngles.z;

		pivotPoint.localRotation = Quaternion.Euler(pivotPoint.localRotation.eulerAngles.x, 359, pivotPoint.localRotation.eulerAngles.z);
		while (pivotPoint.localRotation.eulerAngles.z != 180) {
			yield return new WaitForEndOfFrame();

			if (stats.swingSpeed * Time.deltaTime >= pivotPoint.localRotation.eulerAngles.y - 180) {
				pivotPoint.localRotation = Quaternion.Euler(pivotPoint.localRotation.eulerAngles.x, 180, pivotPoint.localRotation.eulerAngles.z);
				break;
			}
#pragma warning disable CS0618 // Type or member is obsolete
			pivotPoint.RotateAroundLocal(Vector3.up, -stats.swingSpeed * Time.deltaTime);
#pragma warning restore CS0618 // Type or member is obsolete

		}
		yield return new WaitForSeconds(secondDelayAfterSwordSwing);
		SwordSwingFinished();
	}

	public void PrepareMeleeAttack() { 
		boxCollider.enabled = true;
		meshRenderer.enabled = true;
	}

	void SwordSwingFinished() {
		boxCollider.enabled = false;
		meshRenderer.enabled = false;

		pivotPoint.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, originalRotation);
	}

	private void OnTriggerEnter(Collider other) {
		other.gameObject.GetComponent<Enemy>().WasHit(stats.damage);
	}

	void ShowHitBox() {
		bool showingHitbox = hitboxVisual.activeSelf;
		
		if (debugHitbox && !showingHitbox) {
			hitboxVisual.SetActive(true);
			showingHitbox = true;
		} 
		else if (!debugHitbox && showingHitbox) {
			hitboxVisual.SetActive(false);
			showingHitbox = false;
		}
	}
}