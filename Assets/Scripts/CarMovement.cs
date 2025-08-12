using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  // �������� ������
    [SerializeField] private float despawnZ = -30f; // ������� �� ���� ������ �����

    private void Update()
    {
        if(UIManager.isGameOver)
        {
            return;
        }
        // ������ ������ � ������� ������
        transform.Translate(Vector3.forward * speed);

        // ����� ��� ��������, ���� ������ ������ �� ���� ��������� � ����� despawnZ 
        if (transform.position.z < despawnZ)
        {
            // ������� ��'���
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ ��'��� Player � �������� �������
        FindObjectOfType<Player>().AnimationDead();
        // ������ ��'��� UIManager �� ���� � ��������� ����� ��������
        FindObjectOfType<UIManager>().GameOver();
        // ��������� ��'���
        Destroy(gameObject);
    }
}
