using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move the projectile downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Destroy the projectile when it goes off-screen
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger game over when projectile hits the player
            FindFirstObjectByType<GameManager>().GameOver();
            // Optionally, you can add code to destroy the player here if you have implemented such logic.
            Destroy(gameObject); // Destroy the enemy projectile
        }
    }
}
