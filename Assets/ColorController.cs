using UnityEngine;
using UnityEngine.Networking;

public class ColorController : NetworkBehaviour
{
    [SyncVar]
    private Color color = Color.white;
    
    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isLocalPlayer) // allow only ourselves to change the color
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ask the server to change our color
                CmdChangeColor();
            }
        }

        // update the color with the value received from the server
        renderer.material.color = color;
    }

    [Command]
    private void CmdChangeColor()
    {
        // change the color in all the clients
        color = new Color(Random.value, Random.value, Random.value, 1f);
    }
}
