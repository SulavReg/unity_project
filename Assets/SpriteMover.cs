using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float speed = 5f;

    // Method to set speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move the sprite to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        // Destroy the sprite when it goes off-screen
        Destroy(gameObject);
    }
}
