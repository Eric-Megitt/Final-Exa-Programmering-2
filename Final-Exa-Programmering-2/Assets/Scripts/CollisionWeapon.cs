using UnityEngine;

public class CollisionWeapon : Singleton<CollisionWeapon> {
	//Cached references
	[SerializeField] public CollisionWeaponStats stats;
	[SerializeField] private Transform bulletSpawnPoint;
	[SerializeField] private GameObject bulletPrefab;

	//Private variables
	private float timeSinceLastShot;


	private void Update() {
		timeSinceLastShot += Time.deltaTime;
	}

	private bool CanShoot() => timeSinceLastShot > 1f / stats.fireRatePerSecond;

	public void Shoot() {
		if (CanShoot()) {
			var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * stats.bulletSpeed;

			timeSinceLastShot = 0;
		}
	}
}