using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;  // �������� ������
    [SerializeField] private CharacterController characterController;   // ��������� ��� ���������� ���������, �� ������� Rigidbody
    // ��������� ���� �� ��������� �
    private float minX = -4f;
    private float maxX = 4f;

    private void Update()
    {
        // ��������� ���������� ������ (A & D) ��� ������ (������ / ����) � ������� �� ��������
        float moveX = Input.GetAxis("Horizontal") * speed;

        // ��������� ��� ����� �� X
        Vector3 move = new Vector3(moveX, 0, 0);

        // ������ ��� ��������� � ������� Time.deltatime, ��� ���� ��� �������� ���� ���� ��������� �� ���� ����� FPS
        characterController.Move(move * Time.deltaTime);

        // ������ ������� ������� ������
        Vector3 pos = transform.position;

        // � ���� Mathf ������  �����  Clamp  ��� ��������� ���� ������ �� X, ��� ���� ��� �� ���������� ���� ��������� � ��� ������� �� ������� �� ��� ������
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // ������� �������� ������� �����, ��� ���� ��� ������� �� ����������� � ���� �����
        transform.position = pos;
    }
}
