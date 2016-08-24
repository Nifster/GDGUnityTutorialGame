using UnityEngine;
using System.Collections;

// This is a game manager script. Attach it to something.

/** 
 * HOW IT WORKS:
 * 
 * The script does the following:
 *
 * ==ONE==
 * Every X seconds, spawn a new prefabCollectible in the map.
 *   - X is determined by the variable "spawnCooldown"
 *
 * ==TWO==
 * Keep an integer variable named "score".
 *   - The function "ItemCollected" is called from Collectible.cs whenever an item is collected.
 *   - Whenever "ItemCollected" is called, increment score by 1.
 *
 * ==THREE==
 * Draw a number indicating the score on the in-game GUI
 * 
 * ==FOUR==
 * [Not Essential]
 * Draw some white guide lines in the Unity Editor to indicate the spawn area box.
 *
 */

public class GameManager : MonoBehaviour {

	public static GameManager instance {get; private set;}

	// NOTE: Anything with [SerializeField] is editable in the unity editor.

	[SerializeField]
	private GameObject prefabCollectible = null;

	//[SerializeField]
	private Rect scoreRect = new Rect(40,40,200,100);
	
	//[SerializeField]
	private GUIStyle scoreGuiStyle;

	private int score;

	[SerializeField]
	private Vector2 spawnLimitBottomLeft = new Vector2(-7,-4.5f);
	[SerializeField]
	private Vector2 spawnLimitTopRight = new Vector2(7, 4.5f);

	private float nextSpawnTime;

	[SerializeField]
	private float spawnCooldown = 1f;

	private int collectibleCount;
	[SerializeField]
	private int collectibleLimit = 10;

	// Awake is called before start.
	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		CheckForErrors();

		score = 0;
		nextSpawnTime = Time.time + spawnCooldown;
	}

	public void ItemCollected() {
		score++;
		collectibleCount--;
	}

    public void ModifyScore(int scoreChange) {
        score += scoreChange;
    }

    public void IncrementCollectibleCount() {
		collectibleCount++;
	}

	private void SpawnCollectible() {
		float spawnX = Random.Range(spawnLimitBottomLeft.x, spawnLimitTopRight.x);
		float spawnY = Random.Range(spawnLimitBottomLeft.y, spawnLimitTopRight.y);

		Instantiate(prefabCollectible, new Vector3(spawnX, spawnY, 0), prefabCollectible.transform.rotation);
	}

	// Update() : Update is called once per frame
	void Update() {
		// Controls the spawning of collectibles
		if (prefabCollectible != null && Time.time > nextSpawnTime) {
			nextSpawnTime += spawnCooldown;

			if (collectibleCount < collectibleLimit)
				SpawnCollectible();
		}
	}

	// OnGUI() : Use this for drawing things directly on to the screen.
	void OnGUI() {
		GUI.Label(scoreRect, score.ToString(), scoreGuiStyle);
	}

	// OnDrawGizmos() : This draws the white guidelines in the unity editor.
	void OnDrawGizmos() {
		Gizmos.DrawLine (new Vector3(spawnLimitBottomLeft.x, spawnLimitBottomLeft.y, 0),
		                 new Vector3(spawnLimitBottomLeft.x, spawnLimitTopRight.y, 0));
		Gizmos.DrawLine (new Vector3(spawnLimitBottomLeft.x, spawnLimitBottomLeft.y, 0),
		                 new Vector3(spawnLimitTopRight.x, spawnLimitBottomLeft.y, 0));
		Gizmos.DrawLine (new Vector3(spawnLimitTopRight.x, spawnLimitTopRight.y, 0),
		                 new Vector3(spawnLimitBottomLeft.x, spawnLimitTopRight.y, 0));
		Gizmos.DrawLine (new Vector3(spawnLimitTopRight.x, spawnLimitTopRight.y, 0),
		                 new Vector3(spawnLimitTopRight.x, spawnLimitBottomLeft.y, 0));
	}


	// This function is not important.
	// I made it just to diagnose some possible errors that you might make during the workshop :D
	void CheckForErrors() {
		// Initialise font style if not set.
		if (scoreGuiStyle == null) {
			scoreGuiStyle = new GUIStyle ();
			scoreGuiStyle.fontSize = 20;
			scoreGuiStyle.normal.textColor = Color.white;
		}
		if (prefabCollectible == null)
			Debug.Log ("NUSGDG: The GameManager's collectible prefab has not been assigned! The GameManager can't spawn any collectibles.");
	}
}
