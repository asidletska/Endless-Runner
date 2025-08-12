using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;    // ����� ��������
    [SerializeField] private Transform spawnPoint;  // ����� ����� ��� ��������
    [SerializeField] private int maxCount = 20;  // ����������� ������� �������� �� ����
    private float platformLength = 38f;  // ������� ���������
    private Queue<GameObject> activePlatforms = new Queue<GameObject>();    // ��������� �����, �� ����������� �� ������ ��������� �� ����

    private void Start()
    {
        // ����, ���� ������� ��������� �� ������� ���
        for (int i = 0; i < maxCount; i++)
        {
            SpawnPlatforms();
        }
    }
    private void Update()
    {
        if (UIManager.isGameOver)
        {
            return;
        }
        // ����������, ���� ��������� ������ ��������� ����
        if (activePlatforms.Count > 0 && activePlatforms.Peek() == null)
        {
            // ���������� ����� ��������� ��� �� ���� ����� �� �������
            activePlatforms.Dequeue();
            // ��������� ����
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        Vector3 spawnPos;

        if (activePlatforms.Count > 0)
        {
            // ������ ������� ��������� � ����
            GameObject lastPlatform = null;
            foreach (var plat in activePlatforms) lastPlatform = plat;

            // �������� ������ ���� �������� ���������
            spawnPos = lastPlatform.transform.position + Vector3.forward * platformLength;
        }
        else
        {
            // ���� �� ����� ���������
            spawnPos = spawnPoint.position;
        }

        // ��������� ���������
        GameObject platform = Instantiate(platforms[Random.Range(0, platforms.Length)], spawnPos, Quaternion.identity);

        // ������ � �����
        activePlatforms.Enqueue(platform);
    }
}
