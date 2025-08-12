using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;  // швидк≥сть монет
    [SerializeField] private float despawnZ = -30f; // позиц≥€ за €кою монета зникаЇ

    private void Update()
    {
        if (UIManager.isGameOver)
        {
            return;
        }
        // рухаЇмо монети в сторону гравц€
        transform.Translate(Vector3.back * speed);

        // умова €ка перев≥р€Ї, €кщо монета вийшла за межу визначену в зм≥нн≥й despawnZ 
        if (transform.position.z < despawnZ)
        {
            // знищуЇмо об'Їкт
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // шукаЇмо об'Їкт GameManager на сцен≥ ≥ викликаЇмо метод  додаванн€ монет
        FindObjectOfType<GameManager>().AddCoin();
        // видал€Їмо об'Їкт
        Destroy(gameObject);
    }
}
