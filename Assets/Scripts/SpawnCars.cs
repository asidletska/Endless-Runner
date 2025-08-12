using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject[] cars; // ����� ������� �����
    [SerializeField] private float spawnCar = 40f;  // ������� ������ �����
    [SerializeField] private float spawnInterval = 2f;  // �������� ������ �����
    private float timer;    // ������ ��� ���������� ������ �����

    private void Update()
    {
        // �������� ������
        timer += Time.deltaTime;
        // �����, ���� ������ �����-������� ��������� ������ �����
        if (timer >= spawnInterval)
        {
            // ��� ��������� ����� ������ �����
            SpawnCar();
            // ������ ���������
            timer = 0;
        }
    }

    private void SpawnCar()
    {
        // �������� ������ ������ � ������ �����
        GameObject car = cars[Random.Range(0, cars.Length)];

        // �������� ��������� -3 ��� 3
        float posX = Random.value > 0.5f ? 3f : -3f;

        // ��������� ������� ��� ������ �����
        Vector3 spawnPos = new Vector3(posX, 0, spawnCar);

        // ��������� ������ ������ �� �� y �� 180 
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        // ��������� ������, ������� ����� ������ � ������� ������
        Instantiate(car, spawnPos, rotation);
    }

}
