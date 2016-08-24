using UnityEngine;
using System.Collections;

// Attach this script to make an object into a collectible.

/** 
 * HOW IT WORKS:
 * Note: Requires the GameManager.cs script to be attached to something in the scene.
 * 
 * This script makes it so that when something enters its hitbox, do
 * 	1) Check if it is the player that entered. If not, return.
 *  2) Tell the GameManager that an item has been collected.
 *  3) Delete itself
 */

public class Collectible : MonoBehaviour {

	private GameManager gameManager;

    [SerializeField]
    private string collectorName = "Player";

	// Called on start
	void Start() {
		CheckForErrors();

		gameManager = GameManager.instance;
		if (gameManager != null)
			gameManager.IncrementCollectibleCount();

	}

	// Called when some other object enters your hitbox. (note: isTrigger must be on!)
	void OnTriggerEnter2D(Collider2D other) {
		// First we need to check whether the thing it's colliding with is the player.
		// There are a few methods to do this. I'll be using Method 1.

		// Method 1: Check object name (I'm using this)
		if (other.name.ToLower() != collectorName.ToLower()) return;

		// Method 2: Check object tag (I'm not using this)
		//if (other.tag != 7) return;

		// Method 3: Check whether object has the script component "Controller" attached. (I'm not using this)
		//var controller = other.GetComponent<Controller>();
		//if(controller == null) return;

		if (gameManager != null) {
			gameManager.ItemCollected();
		}
		Destroy(this.gameObject);
	}

	// This function is not important.
	// I made it just to diagnose some possible errors that you might make during the workshop :D
	private void CheckForErrors() {
		var colliders = this.GetComponents<Collider2D>();
		if (colliders == null || colliders.Length == 0) {
			Debug.Log ("NUSGDG: Attach a collider to your collectible!");
		}
		bool hasTriggerCollider = false;
		foreach (var collider in colliders) {
			if (collider.isTrigger)
				hasTriggerCollider = true;
		}
		if (!hasTriggerCollider) {
			Debug.Log ("NUSGDG: Set isTrigger (in the Box Collider 2D settings) to true for the pickup to work");
		}
	}
}
