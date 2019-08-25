using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject enemy;
    public int enemyCount;
    public float spawnWaitEnemy;
    public float startWaitEnemy;
    public float waveWaitEnemy;

    public GameObject hazard;
    public int hazardCount;
    public float spawnWaitHazard;
    public float startWaitHazard;
    public float waveWaitHazard;

    public GameObject powerUp;
    public int powerUpCount;
    public float spawnWaitPowerUp;
    public float startWaitPowerUp;
    public float waveWaitPowerUp;
    public Text scoreText;
    public int score;
    // public float scrollSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnEnemyWaves ());
        StartCoroutine (SpawnHazardWaves ());
        StartCoroutine (SpawnPowerUp ());
    }

   IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds (startWaitHazard);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                // GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x) + 0.5f, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWaitEnemy);
                if(score > 100) 
                {
                    waveWaitEnemy = 3;
                    enemyCount = 3;
                }
                if(score > 200) 
                {
                    waveWaitEnemy = 1;
                    enemyCount = 5;
                }
            }
            yield return new WaitForSeconds (waveWaitEnemy);
        }
    }

    IEnumerator SpawnHazardWaves()
    {
        yield return new WaitForSeconds (startWaitHazard);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x) + 0.5f, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWaitHazard);
            }
            hazardCount++;
            yield return new WaitForSeconds (waveWaitHazard);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds (startWaitPowerUp);
        while (true)
        {
            for (int i = 0; i < powerUpCount; i++)
            {

                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (powerUp, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWaitPowerUp);
            }
            yield return new WaitForSeconds (waveWaitPowerUp);
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        Debug.Log("pontuação aumenta: " + score);
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }
}
