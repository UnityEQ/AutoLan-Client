using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
 
public class NetDiscovery : NetworkDiscovery {
	public bool connected = false;
    public NetDiscovery()
    {
		broadcastPort = 8080;
		broadcastInterval = 1000;
		broadcastKey = 2222;
		broadcastVersion = 1;
		broadcastSubVersion = 1;
		useNetworkManager = true;
		showGUI = true;
		
	}
 
	void Start()
	{
		Initialize();
		StartAsClient();
		//StartAsServer();
		
	}
	
	public override void OnReceivedBroadcast(string fromAddress, string data)
	{
		if(!connected)
		{
			connected = true;
			NetworkManager.singleton.networkAddress = fromAddress;
			NetworkManager.singleton.StartClient();
		}
		Debug.Log("Broadcast: " + fromAddress);
	}
	
	

	
}