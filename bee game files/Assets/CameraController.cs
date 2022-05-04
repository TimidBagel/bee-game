using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DO NOT FORMAT THIS DOCUMENT
 */

public class CameraController : MonoBehaviour
{
	public Transform cameraTransform;
	public Camera cam;

	public float normalSpeed;
	public float fastSpeed;
	private float movementSpeed;
	public float movementTime;
	public float rotationAmount;
	public float zoomAmount;
	public float targetSize;

	public Vector3 newPosition;
	public Quaternion newRotation;

	public Vector3 dragStartPosition;
	public Vector3 dragCurrentPosition;

	private void Start()
	{
		newPosition = transform.position;
		newRotation = transform.rotation;
	}

	private void Update()
	{
		HandleMouseInput();
		HandleMovement();
	}

	private void HandleMouseInput()
	{
		if (Input.mouseScrollDelta.y != 0)
			targetSize -= Input.mouseScrollDelta.y * zoomAmount * Time.deltaTime * 10;
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

//		- alters rotation variable based on keyboard input
		if (Input.GetKey(KeyCode.Q))
			newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
		if (Input.GetKey(KeyCode.E))
			newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);

//		- changes the camera size target based on keyboard input, must be greater than 1
		if (Input.GetKey(KeyCode.F) && targetSize < 20)
			targetSize += zoomAmount * Time.deltaTime;
		if (Input.GetKey(KeyCode.R) && cam.orthographicSize > 1)
			targetSize -= zoomAmount * Time.deltaTime;
		if (targetSize <= 1)
			targetSize = 1;
		if (targetSize >= 20)
			targetSize = 20;
		if (cam.orthographicSize < 1)
			cam.orthographicSize = 1;
		if (cam.orthographicSize > 20)
			cam.orthographicSize = 20;

//		- gradually moves the camera based on altered movement variable over time
		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
//		- gradually rotates the camera based on altered rotation variable over time
		transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
//		- gradually increases and decreases the camera size based on altered camera size target variable over time
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomAmount);
	}
}
