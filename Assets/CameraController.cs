using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour
{


	public new GameObject camera;

	private void Start()
	{
		camera.SetActive(isLocalPlayer);
	}
}
