using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region singleton
	public static GameManager gameInstance;
	private void Awake()
	{
		if (gameInstance != null)
		{
			Debug.LogWarning("<WARNING> MORE THAN ONE INSTANCE OF GAMEMANAGER FOUND IN SCENE </WARNING>");
			return;
		} else { gameInstance = this; }
	}
	#endregion
	#region setting random waypoints
	public GameObject plane;

	public Vector3 GetRandomPoint(GameObject plane)
	{
		Vector3 point;

		List<Vector3> VerticeList = new List<Vector3>
			(plane.GetComponent<MeshFilter>().sharedMesh.vertices);

		Vector3 leftTop = plane.transform.TransformPoint(VerticeList[0]);
		Vector3 rightTop = plane.transform.TransformPoint(VerticeList[10]);
		Vector3 leftBottom = plane.transform.TransformPoint(VerticeList[110]);
		Vector3 rightBottom = plane.transform.TransformPoint(VerticeList[120]);

		Vector3 XAxis = rightTop - leftTop;
		Vector3 ZAxis = leftBottom - leftTop;

		point = leftTop + XAxis * Random.value + ZAxis * Random.value;
		return point;
	}

	public Vector3[] GetWaypoints(int count)
	{
		Vector3[] waypoints = new Vector3[count];
		
		for (int i = 0; i < count; i++) { waypoints[i] = GetRandomPoint(plane); }
		return waypoints;
	}
	#endregion

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SceneManager.LoadScene(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SceneManager.LoadScene(1);
		}

	}
}
