using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform activeRoom;

    [Range(-5, 5)]
    public float minModX, maxModX, minModY, maxModY;
    


    public static CameraController instance;

	private void Awake()
	{
		if (instance == null)
		{
            instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );

        transform.position = new Vector3(clampedPos.x, clampedPos.y, clampedPos.y);
    }
}
