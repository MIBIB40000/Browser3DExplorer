using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] float speed = 2f;

	public float startingFOV;

	public float minPOV = 20f;
	public float maxPOV = 70f;
	public float zoomRate = 0.01f;

	public float currentFOV;

	public void Start()
	{
		startingFOV = cam.fieldOfView;
		currentFOV = startingFOV;
	}

	void Update()
	{
		MakeZoom();
		//if (Input.GetAxis("Mouse ScrollWheel") > 0)
		//{
		//	if (cam.fieldOfView > minPOV)
		//	{
		//		cam.fieldOfView--;
		//	}
		//}
		//if (Input.GetAxis("Mouse ScrollWheel") < 0)
		//{
		//	if (cam.fieldOfView < maxPOV)
		//	{
		//		cam.fieldOfView++;
		//	}
		//}

		if (Input.GetMouseButton(0))
		{
			transform.eulerAngles += -speed * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		}

		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	currentFOV = startingFOV;
		//}

		//if (Input.GetKey(KeyCode.W))
		//{
		//	currentFOV += zoomRate;
		//}
	}

	public void MakeZoom()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (cam.fieldOfView > minPOV)
			{
				cam.fieldOfView--;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (cam.fieldOfView < maxPOV)
			{
				cam.fieldOfView++;
			}
		}
	}
}
