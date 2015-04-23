using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public GameObject enemy1;
	public GameObject hazard2;
	public GameObject hardwick;
	public Vector3 spawnValue;
	public int hazardCount;
	public int enemyCount;
	public int hardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{

			for (int i = 0;i < hazardCount;i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}

			for (int i = 0;i < hazardCount;i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard2, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}

			for (int j = 0; j < enemyCount; j++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy1, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}

			for (int k = 0; k < hardCount; k++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hardwick, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			hazardCount = hazardCount * 2;
			enemyCount = enemyCount * 2;
			EnemyMover.speed = EnemyMover.speed - 2;
			PlayerController.fireRate = PlayerController.fireRate - .07f;
			PlayerController.speed = PlayerController.speed + 3;
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				EnemyMover.speed = -3;
				PlayerController.speed = 10;
				PlayerController.fireRate = .5f;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
