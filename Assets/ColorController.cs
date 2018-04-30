using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Renderer))]
public class ColorController : NetworkBehaviour
{

	[SyncVar] private Color color = Color.white;
	private Renderer renderer;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isLocalPlayer)
		{
			CmdChangeColor();
		}

		renderer.material.color = color;
	}

	[Command]
	private void CmdChangeColor()
	{
		color = new Color(Random.value, Random.value, Random.value, 1f);
	}
}
