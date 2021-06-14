using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]private GameObject placeableObjectPrefab;
	private GameObject currentObject;
	private float mouseRotation;
	private KeyCode objectCode = KeyCode.Space;

	private void Start()
	{
		CreateObject();
	}
	private void Update()
	{
		

		if(currentObject != null)
		{
			MoveCurrentObjectToMouse();
			RotateFromMouse();
			ReleaseIfClicked();
		}
	}

	private void ReleaseIfClicked()
	{
		if (Input.GetKeyDown(objectCode))
		{
			currentObject = null;
		}
	}

	private void RotateFromMouse()
	{
		mouseRotation += Input.mouseScrollDelta.y;
		currentObject.transform.Rotate(Vector3.up, mouseRotation * 10f);
	}

	private void MoveCurrentObjectToMouse()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;

		if(Physics.Raycast(ray, out hitInfo))
		{
			currentObject.transform.position = hitInfo.point;
			currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
		}
	}

	public void CreateObject()
	{
			currentObject = Instantiate(placeableObjectPrefab);
	}

}
