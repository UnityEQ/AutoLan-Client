using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class ClientManager : NetworkBehaviour {

//	[SyncVar(hook = "setName")]
//	public string gameObjectName;
 	
	public void setName(string newName)
	{
//		gameObjectName = newName;
	}
	
	void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
		
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
	
	public override void OnStartLocalPlayer()
	{
//		setName("poop");
		//Add Player to PlayerList Array for MainCamera Script
		PlayerArray.Instance.PlayerList.Add(this.gameObject);
		//Set Player GameObject Name
		this.gameObject.name = "player_" + connectionToServer.connectionId;
		//Find MainCamera Object
		GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		//Set MainCamera to follow this playerId
		MainCamera.GetComponent<CameraFollow>().cameraPlayerId = connectionToServer.connectionId;
		//Set MainCamera to switch to the playerId
		MainCamera.GetComponent<CameraFollow>().cameraSwitch = true;
		//Register a handler for a particular message type, in this case it is MainCamera Switch
	}
}
