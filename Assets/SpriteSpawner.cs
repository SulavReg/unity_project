using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab;       // The sprite prefab to spawn
    public Transform knightTransform;     // Reference to the knight's transform
    public float spawnInterval = 2f;      // Time between spawns
    public float spawnSpeed = 5f;         // Base speed of the sprites

    private bool isGameOver = false;

    void Start()
    {
        StartCoroutine(SpawnSprites());
    }

    IEnumerator SpawnSprites()
    {
        while (!isGameOver)
        {
            SpawnSprite();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnSprite()
    {
        // Define two specific heights in world space: one low and one high
        float lowHeight = knightTransform.position.y - 1.5f;  // Much lower
        float highHeight = knightTransform.position.y + 2f;   // Slightly higher

        // Randomly choose between the two heights
        float spawnHeight = Random.value > 0.5f ? lowHeight : highHeight;

        // Get the right side of the camera’s viewport in world space
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        spawnPosition.y = spawnHeight;
        spawnPosition.z = 0; // Set Z to 0 to ensure it spawns on the same plane as other 2D objects

        // Instantiate the candy corn sprite at the calculated spawn position
        GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

        // Set the movement speed on the sprite
        SpriteMover mover = newSprite.GetComponent<SpriteMover>();
        
    }


    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
