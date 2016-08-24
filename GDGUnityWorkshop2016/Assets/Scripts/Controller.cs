using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

	// Use this for initialization
	void Start ()
	{
	    //Debug.Log("Hello World!");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Debug.Log("Hello World - Update!");
	    var rigidbody = GetComponent<Rigidbody2D>();
        var velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * speed;
        }

	    rigidbody.velocity = velocity;
	}

    public void IncreaseSpeed(float increment)
    {
        speed += increment;
    }
}
