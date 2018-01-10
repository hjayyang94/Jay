using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceVertical;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	private Vector3 targetPosition;



	// Use this for initialization
	void Start () 
	{
		follow = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void LateUpdate () 
	{
		targetPosition = follow.position + follow.up * distanceVertical - follow.forward * distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (follow);
	}

}
