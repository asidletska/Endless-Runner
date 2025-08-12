using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  // швидк≥сть машини
    [SerializeField] private float despawnZ = -30f; // позиц≥€ за €кою машина зникаЇ

    private void Update()
    {
        if(UIManager.isGameOver)
        {
            return;
        }
        // рухаЇмо машину в сторону гравц€
        transform.Translate(Vector3.forward * speed);

        // умова €ка перев≥р€Ї, €кщо машина вийшла за межу визначену в зм≥нн≥й despawnZ 
        if (transform.position.z < despawnZ)
        {
            // знищуЇмо об'Їкт
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // шукаЇмо об'Їкт Player ≥ програЇмо ан≥мац≥ю
        FindObjectOfType<Player>().AnimationDead();
        // шукаЇмо об'Їкт UIManager на сцен≥ ≥ викликаЇмо метод програшу
        FindObjectOfType<UIManager>().GameOver();
        // видал€Їмо об'Їкт
        Destroy(gameObject);
    }
}
