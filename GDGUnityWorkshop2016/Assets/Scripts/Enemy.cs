using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float activeRange;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //Get distance to player
        Vector2 playerDist = (playerObj.transform.position - transform.position);
        //Debug.Log(playerDist.magnitude);

        Vector2 velocity = Vector2.zero;
        if (playerDist.magnitude < activeRange)
        {
            //Debug.Log("Player DETECTED");
            //follow player
            velocity += playerDist.normalized * speed;
        }
        rigidbody.velocity = velocity;
    }
}
