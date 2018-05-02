using UnityEngine;
using UnityEngine.Networking;

public class ExplosionController : NetworkBehaviour
{
    public GameObject hugeExplosion;

    private void Update()
    {
        if (!isLocalPlayer) // allow only ourselves to change the color
        {
            return;
        }

        if (Input.GetKey(KeyCode.E))
        {
            // ask the server to render an explosion
            CmdExplode();
        }
    }

    [Command]
    private void CmdExplode()
    {
        // tell the clients to render an explosion
        RpcExplode();
    }

    [ClientRpc]
    private void RpcExplode()
    {
        // KA-BOOM!
        GameObject instance = Instantiate(hugeExplosion, transform.position, Quaternion.identity);
        Destroy(instance, 2);
    }
}
