using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollisionWeaponData", menuName = "ScriptableObjects/CollisionWeaponStats", order = 2)]
public class CollisionWeaponStats : ScriptableObject
{
	public float damage;
	public float fireRatePerSecond;
	public float maxDistance;
	public float bulletSpeed;
}
