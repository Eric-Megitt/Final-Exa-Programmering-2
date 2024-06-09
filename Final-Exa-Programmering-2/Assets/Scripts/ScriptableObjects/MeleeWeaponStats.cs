using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class MeleeWeaponStats : ScriptableObject
{
	public float damage = 100;
	public float swingSpeed = 1;
}
