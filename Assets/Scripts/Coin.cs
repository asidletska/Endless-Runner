using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;  // �������� �����
    [SerializeField] private float despawnZ = -30f; // ������� �� ���� ������ �����

    private void Update()
    {
        if (UIManager.isGameOver)
        {
            return;
        }
        // ������ ������ � ������� ������
        transform.Translate(Vector3.back * speed);

        // ����� ��� ��������, ���� ������ ������ �� ���� ��������� � ����� despawnZ 
        if (transform.position.z < despawnZ)
        {
            // ������� ��'���
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ ��'��� GameManager �� ���� � ��������� �����  ��������� �����
        FindObjectOfType<GameManager>().AddCoin();
        // ��������� ��'���
        Destroy(gameObject);
    }
}
