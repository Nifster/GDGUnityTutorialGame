using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Vector2 mousePos = new Vector2();
    private Vector2 lookDirection = new Vector2();

    [SerializeField]
    private GameObject muzzle;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

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

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right * speed;
        }

	    rigidbody.velocity = velocity;

        LookAtMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void IncreaseSpeed(float increment)
    {
        speed += increment;
    }

    private void LookAtMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = (mousePos - (Vector2)transform.position).normalized;
        transform.right = lookDirection;
    }

    private void Shoot()
    {
        //Not the best way to do shooting, but it's the easiest
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = muzzle.transform.position;
        newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * (lookDirection * speed);

    }
}
