using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RaycastWeaponData", menuName = "ScriptableObjects/RaycastWeaponStats", order = 3)]
public class RaycastWeaponStats : ScriptableObject
{
	public float damage;
	public float fireRatePerSecond;
	public float maxDistance;
}
