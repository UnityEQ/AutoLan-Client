using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
	public float yRotation = 5.0F;
    public Vector3 offset;
	
	//two vars needed for remote camera change
	public int cameraPlayerId;
	public bool cameraSwitch = false;
	
    
    void Start () 
    {
        
        offset = new Vector3(0,1,-5);
    }
	
	void Update()
	{
		//player will self destruct on net disconnect but before scene change, added so you don't get a MissingReferenceException
		if(player != null)
		{
			transform.forward = player.transform.position - transform.position;
		}	
			//Remote camera change
			if(cameraSwitch)
			{
				cameraSwitch = false;
				for(int i = 0; i < PlayerArray.Instance.PlayerList.Count; i++)
				{
					if(PlayerArray.Instance.PlayerList[i].name == "player_" + cameraPlayerId)
					{
						player = PlayerArray.Instance.PlayerList[i];
					}
				}
			}
	}
    
    
    void LateUpdate () 
    {
        if(player != null)
		{
			transform.position = player.transform.position + offset;
		}
    }
}