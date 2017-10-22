using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
 
public class NetManager : NetworkManager {
	
	void Start()
	{
		networkAddress = "255.255.255.255";
	}
	
	//this is called when a client disconnects from server
    public override void OnClientDisconnect (NetworkConnection conn)
    {
		StopClient();
		Debug.Log("DISCONN");
		networkAddress = "255.255.255.255";
		GetComponent<NetDiscovery>().connected = false;
    }
	
	
}