using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 10f;
	private Transform target;
	private int destPoint = 0;


	void Start () {
		target = WayPoint.points [0];
	}


	void FixedUpdate () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWayPoint();
		}

	}

	void GetNextWayPoint () {

		if (destPoint > WayPoint.points.Length) {
			destPoint = 0;
		}

		destPoint++;
		target = WayPoint.points [destPoint];
	}
}
