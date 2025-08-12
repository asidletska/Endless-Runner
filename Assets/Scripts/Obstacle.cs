using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
