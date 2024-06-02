using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	//Serialized Fields
	[SerializeField] Vector3 relativePositionToPlayer;
	[SerializeField] float relativePitchToPlayer;
	
	
	void Update() {
		Transform playerTransform = GameObject.Find("MrPotatoHead").transform;
		transform.position = playerTransform.position + (Vector3.up * relativePositionToPlayer.y) - (Movement.Instance.TransformBackwards * relativePositionToPlayer.z);
		Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
		float playerYRotationDegrees = Vector3.SignedAngle(RemoveYAxis(-Movement.Instance.TransformBackwards), Vector3.right, Vector3.up);
		transform.rotation = Quaternion.Euler(relativePitchToPlayer, 90-playerYRotationDegrees, 0);
	}
	
	Vector3 RemoveYAxis(Vector3 v) => new(v.x, 0, v.z);
}
