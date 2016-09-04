using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This is a game manager script. Attach it to something.

/** 
 * HOW IT WORKS:
 * 
 * The script does the following:
 *
 * ==ONE==
 * Every X seconds, spawn a new prefabToSpawn in the map.
 *   - X is determined by the variable "spawnCooldown"
 *
 * ==TWO==
 * Keep an integer variable named "score".
 *   - The function "EnemyKilled" is called from Bullet.cs whenever an enemy is killed.
 *   - Whenever "EnemyKilled" is called, increment score by 1.
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
    
	private int score;

    [SerializeField]
    private Text scoreText;
   
    
	// Awake is called before start.
	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {

        score = 0;
	}

	// Update() : Update is called once per frame
	void Update() {

        scoreText.text = score.ToString();
	}
    
    public void EnemyKilled()
    {
        score++;
    }
    
    public void ModifyScore(int scoreChange)
    {
        score += scoreChange;
    }
    
    

}
