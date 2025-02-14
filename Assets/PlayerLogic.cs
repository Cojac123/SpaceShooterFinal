using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 5f;
    public float boundaryX = 7.5f; // Adjust as needed based on your screen size

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        // Clamp the player's position to stay within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -boundaryX, boundaryX);
        transform.position = newPosition;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
