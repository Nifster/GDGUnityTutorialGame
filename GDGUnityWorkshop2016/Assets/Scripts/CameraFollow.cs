using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


    [SerializeField]
    private GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Camera sticks to target (in this case, the player)
        if(targetObj != null)
        {
            transform.localPosition = new Vector3(targetObj.transform.localPosition.x, targetObj.transform.localPosition.y, -10);
        }
        
	}
}
