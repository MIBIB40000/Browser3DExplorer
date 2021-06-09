using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] float speed = 2f;

	public float minPOV = 20f;
	public float maxPOV = 70f;

	void Update()
	{
		MakeZoom();
		MoveCamera();
	}

	public void MoveCamera()
	{
		if (Input.GetMouseButton(0))
		{
			transform.eulerAngles += -speed * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		}
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
