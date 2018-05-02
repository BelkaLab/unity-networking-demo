using UnityEngine;
using UnityEngine.Networking;

public class ExplosionController : NetworkBehaviour
{
    public GameObject explosionPrefab;

    // Update is called once per frame
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey(KeyCode.E))
        {
            CmdExplode();
        }
    }

    [Command]
    private void CmdExplode()
    {
        RpcExplode();
        
    }

    [ClientRpc]
    private void RpcExplode()
    {
        GameObject instance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(instance, 2);
    }
}
