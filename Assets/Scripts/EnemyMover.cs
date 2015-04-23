using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {

	public static float speed = -3;
	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
