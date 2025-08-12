using UnityEngine;

public class Obstacle : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        // шукаємо об'єкт Player і програємо анімацію
        FindObjectOfType<Player>().AnimationDead();
        // шукаємо об'єкт UIManager на сцені і викликаємо метод програшу
        FindObjectOfType<UIManager>().GameOver();
        // видаляємо об'єкт
        Destroy(gameObject);
    }
}
