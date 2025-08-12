using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject coin;   // ������ ������
    [SerializeField] private Transform[] spawnPoints;   // ����� ������ �����
    [SerializeField] private float despawnZ = -30f; // ������� �� ���� ������ �����
    [SerializeField] private float spawnInterval = 2f;  // �������� ������ �����
    private float timer;    // ������ ��� ���������� ������ �����

    private void Update()
    {
        // �������� ������
        timer += Time.deltaTime;
        // �����, ���� ������ �����-������� ��������� ������ ������
        if (timer >= spawnInterval)
        {
            // �������� ������
            SpawnCoin();
            // ������� ������
            timer = 0;
        }
    }

    private void SpawnCoin()
    {
        // �������� ������ ����� ������ ������
        int index = Random.Range(0, spawnPoints.Length);

        //
        Transform spawnPoint = spawnPoints[index];

        // ��������� ������
        Instantiate( coin, spawnPoint.position, Quaternion.identity );
    }
}
