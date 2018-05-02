using UnityEngine;
using UnityEngine.Networking;

public class MovementController : NetworkBehaviour
{
    public float force = 50f;
    public float maxVelocity = 50f;
    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(240f, 260f), 15f, Random.Range(50f, 70f));
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(transform.forward * force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(-transform.forward * force);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(-transform.right * force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(transform.right * force);
        }

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
    }
}
