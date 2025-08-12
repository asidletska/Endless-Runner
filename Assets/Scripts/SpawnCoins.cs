using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject coin;   // префаб монети
    [SerializeField] private Transform[] spawnPoints;   // точки спавну монет
    [SerializeField] private float despawnZ = -30f; // позиція за якою монета зникає
    [SerializeField] private float spawnInterval = 2f;  // інтервал спавну монет
    private float timer;    // таймер для розрахунку спавна монет

    private void Update()
    {
        // збільшуємо таймер
        timer += Time.deltaTime;
        // умова, якщо таймер більше-дорівнює інтервалу спавна монети
        if (timer >= spawnInterval)
        {
            // спавнимо монету
            SpawnCoin();
            // скидаємо таймер
            timer = 0;
        }
    }

    private void SpawnCoin()
    {
        // рандомно вибирає точку спавна монети
        int index = Random.Range(0, spawnPoints.Length);

        //
        Transform spawnPoint = spawnPoints[index];

        // створюємо монету
        Instantiate( coin, spawnPoint.position, Quaternion.identity );
    }
}
