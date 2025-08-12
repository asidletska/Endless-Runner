using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // �������� ���������
    [SerializeField] float despawnZ = -30f; // ������� �� ���� ��������� �����

    private void Update()
    {
        // ������ ��������� ����� 
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // ����� ��� ��������, ���� ��������� ������ �� ���� ��������� � ����� despawnZ
        if (transform.position.z < despawnZ)
        {
            // ������� ��'���
            Destroy(gameObject);
        }
    }
}
