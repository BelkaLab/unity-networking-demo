using UnityEngine;
using UnityEngine.Networking;

public class MovementController : NetworkBehaviour
{
	public float speed = .5f;

	private void Start()
	{
		transform.position = new Vector3(0f, 2f, 0f);
	}

	private void Update()
	{
		if (!isLocalPlayer)
			return;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += transform.forward * speed;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= transform.forward * speed;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= transform.right * speed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += transform.right * speed;
		}
	}
}
