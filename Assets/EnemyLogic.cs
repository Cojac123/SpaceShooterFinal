using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float speed = 2f;
    public int points = 10;
    public GameObject enemyProjectilePrefab;
    public float shootInterval = 3f;

    void Start()
    {
        InvokeRepeating("Shoot", shootInterval, shootInterval);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime,Space.World);
    }

    void Shoot()
    {
        Debug.Log("Shoots laser: ");
        Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            FindFirstObjectByType<GameManager>().AddScore(points);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy enemy when it goes off screen
    }
}
