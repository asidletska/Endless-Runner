using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // швидкість платформи
    [SerializeField] float despawnZ = -30f; // позиція за якою платформа зникає

    private void Update()
    {
        // рухаємо платформу назад 
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // умова яка перевіряє, якщо платформа вийшла за межу визначену в змінній despawnZ
        if (transform.position.z < despawnZ)
        {
            // знищуємо об'єкт
            Destroy(gameObject);
        }
    }
}
