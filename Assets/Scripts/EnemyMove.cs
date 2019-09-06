using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public float t;

	void Update()
	{
		float speed = t;
		Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
		gameObject.transform.position += velocity * Time.deltaTime;
	}

}
