using UnityEngine;

public class RaycastWeapon : MonoBehaviour {
	//Cached references
	[SerializeField] private RaycastWeaponStats stats;
	[SerializeField] LayerMask enemyLayer;

	//Private variables
	private float timeSinceLastShotSeconds;

	private void Update() {
		timeSinceLastShotSeconds += Time.deltaTime;
	}

	private bool CanShoot() => timeSinceLastShotSeconds > 1f / stats.fireRatePerSecond;

	public void Shoot() {
		Ray weaponRay = new Ray(transform.position, transform.forward);

		if (CanShoot()) {
			if (Physics.Raycast(weaponRay, out RaycastHit hitInfo, stats.maxDistance, enemyLayer)) {
				hitInfo.collider.gameObject.GetComponent<Enemy>().WasHit(stats.damage);
			}

			timeSinceLastShotSeconds = 0;
		}
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.magenta;

		Gizmos.DrawRay(transform.position, transform.forward);
	}
}