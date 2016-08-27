using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {

        gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other != null)
        {
            if(other.tag == "Enemy")
            {
                Destroy(other.gameObject);
                gameManager.EnemyKilled();
            }
            Destroy(this.gameObject);
            //TODO: Add a limited range for bullets
        }
        
    }
}
