using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;  // Швидкість гравця
    [SerializeField] private CharacterController characterController;   // Компонент для переміщення персонажу, не потребує Rigidbody
    [SerializeField] private Animator animator;
    // Обмеження руху по координаті Х
    private float minX = -4f;
    private float maxX = 4f;

    private bool isDead = false;

    private void Update()
    {
        // Визначаємо натискання кнопок (A & D) або стрілки (вправо / вліво) і множимо на швидкість
        float moveX = Input.GetAxis("Horizontal") * speed;

        // Створюємо рух тільки по X
        Vector3 move = new Vector3(moveX, 0, 0);

        // Задаємо рух персонажа і множимо Time.deltatime, для того щоб швидкість руху була однаковою на будь якому FPS
        characterController.Move(move * Time.deltaTime);

        // Беремо поточну позицію гравця
        Vector3 pos = transform.position;

        // В класі Mathf беремо  метод  Clamp  для обмеження руху гравця по X, для того щоб не створювати зайві колайдери і щоб гравець не виходив за межі дороги
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // Ставимо обмежену позицію назад, для того щоб гравець міг переміщатись у нову точку
        transform.position = pos;
    }

    public void AnimationDead()
    {
        isDead = true;
        animator.SetTrigger("Die");
    }
}
