using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject[] cars; // Масив префабів машин
    [SerializeField] private float spawnCar = 40f;  // відстань спавна машин
    [SerializeField] private float spawnInterval = 2f;  // інтервал спавна машин
    private float timer;    // таймер для розрахунку спавна машин

    private void Update()
    {
        // збільшуємо таймер
        timer += Time.deltaTime;
        // умова, якщо таймер більше-дорівнює інтервалу спавна машин
        if (timer >= spawnInterval)
        {
            // тоді спрацбовує метод спавна машин
            SpawnCar();
            // таймер скидується
            timer = 0;
        }
    }

    private void SpawnCar()
    {
        // рандомно вибирає машину з масиву машин
        GameObject car = cars[Random.Range(0, cars.Length)];

        // вибираємо випадково -3 або 3
        float posX = Random.value > 0.5f ? 3f : -3f;

        // створюємо позицію для спавна машин
        Vector3 spawnPos = new Vector3(posX, 0, spawnCar);

        // повертаємо префаб машини по осі y на 180 
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        // створюємо машину, вказуємо точку спавну і ротацію машини
        Instantiate(car, spawnPos, rotation);
    }

}
