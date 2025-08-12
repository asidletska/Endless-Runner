using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;    // масив платформ
    [SerializeField] private Transform spawnPoint;  // спавн точка для платформ
    [SerializeField] private int maxCount = 20;  // максимальна кількість платформ на сцені
    private float platformLength = 38f;  // довжина платформи
    private Queue<GameObject> activePlatforms = new Queue<GameObject>();    // структура даних, де зберігаються всі активні платформи на сцені

    private void Start()
    {
        // цикл, який створює платформи на початку гри
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
        // перевіряємо, якщо платформа зникла створюємо нову
        if (activePlatforms.Count > 0 && activePlatforms.Peek() == null)
        {
            // деактивуємо стару платформу так як вона більше не потрібна
            activePlatforms.Dequeue();
            // створюємо нову
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        Vector3 spawnPos;

        if (activePlatforms.Count > 0)
        {
            // беремо останню платформу у черзі
            GameObject lastPlatform = null;
            foreach (var plat in activePlatforms) lastPlatform = plat;

            // спавнимо одразу після останньої платформи
            spawnPos = lastPlatform.transform.position + Vector3.forward * platformLength;
        }
        else
        {
            // якщо це перша платформа
            spawnPos = spawnPoint.position;
        }

        // створюємо платформу
        GameObject platform = Instantiate(platforms[Random.Range(0, platforms.Length)], spawnPos, Quaternion.identity);

        // додаємо у чергу
        activePlatforms.Enqueue(platform);
    }
}
