using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DO NOT FORMAT THIS DOCUMENT
 */

public class CameraController : MonoBehaviour
{
	public Camera cam;
	public Transform focusTransform;

	public float normalSpeed;
	public float fastSpeed;
	private float movementSpeed;
	public float movementTime;
	public float cameraZoomRate;
	public float targetCameraSize;
	public float focusSpeed;

	private Vector3 newPosition;

	private Vector3 dragStartPosition;
	private Vector3 dragCurrentPosition;

	private void Start()
	{
		newPosition = transform.position;
	}

	private void Update()
	{
		if (focusTransform != null)
		{
			transform.position = Vector3.Lerp(transform.position, focusTransform.position, focusSpeed * Time.deltaTime);
			newPosition = focusTransform.position;
		}
		else
		{
			HandleMouseInput();
			HandleMovement();
		}

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || 
			Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
			Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			focusTransform = null;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.layer == 8)
				{
					targetCameraSize = 4;
					focusTransform = hit.transform;
				}
			}
		}
		HandleZooming();
	}

	private void HandleMouseInput()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Plane plane = new Plane(Vector3.up, Vector3.zero);

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			float entry;

			if (plane.Raycast(ray, out entry))
			{
				dragStartPosition = ray.GetPoint(entry);
			}
		}
		if (Input.GetMouseButton(1))
		{
			Plane plane = new Plane(Vector3.up, Vector3.zero);

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			float entry;

			if (plane.Raycast(ray, out entry))
			{
				dragCurrentPosition = ray.GetPoint(entry);

				newPosition = transform.position + dragStartPosition - dragCurrentPosition;
			}
		}
	}

	private void HandleMovement()
	{
//		- checks if shift is down, if so, movement speed increased -
		if (Input.GetKey(KeyCode.LeftShift))
			movementSpeed = fastSpeed;
		else
			movementSpeed = normalSpeed;

//		- alters movement variable based on up/down/left/right input
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			newPosition += (transform.forward * movementSpeed);
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			newPosition += (transform.forward * -movementSpeed);
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			newPosition += (transform.right * -movementSpeed);
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			newPosition += (transform.right * movementSpeed);

//		- gradually moves the camera based on altered movement variable over time
		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);		
	}

	private void HandleZooming()
	{
//		- changes camera size target based on scroll wheel movement
		if (Input.mouseScrollDelta.y != 0)
			targetCameraSize -= Input.mouseScrollDelta.y * cameraZoomRate * Time.deltaTime * 10;

//		- changes the camera size target based on keyboard input, must be greater than 1
		if (Input.GetKey(KeyCode.F) && targetCameraSize < 20)
			targetCameraSize += cameraZoomRate * Time.deltaTime;
		if (Input.GetKey(KeyCode.R) && cam.orthographicSize > 1)
			targetCameraSize -= cameraZoomRate * Time.deltaTime;
		if (targetCameraSize <= 1)
			targetCameraSize = 1;
		if (targetCameraSize >= 20)
			targetCameraSize = 20;
		if (cam.orthographicSize < 1)
			cam.orthographicSize = 1;
		if (cam.orthographicSize > 20)
			cam.orthographicSize = 20;

//		- gradually increases and decreases the camera size based on altered camera size target variable over time
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetCameraSize, Time.deltaTime * cameraZoomRate);
	}
}
