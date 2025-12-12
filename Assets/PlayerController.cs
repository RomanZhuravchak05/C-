using UnityEngine;
using UnityEngine.InputSystem; // Обов'язково підключаємо простір імен Input System

public class PlayerController : MonoBehaviour
{
    [Header("Параметри руху")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Renderer playerRenderer;
    private Color originalColor;

    void Awake()
    {
        // Отримуємо посилання на компоненти при старті
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    // 1. Логіка отримання вводу (працює завдяки PlayerInput "Send Messages")
    // Метод викликається автоматично, коли натискаємо WASD
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Метод викликається автоматично, коли натискаємо Space
    void OnJump(InputValue value)
    {
        // Стрибаємо тільки якщо натиснули кнопку і (бажано) якщо ми на землі
        // Тут проста перевірка: якщо вертикальна швидкість майже 0, то ми на землі
        if (value.isPressed && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // 2. Фізика руху (виконується у FixedUpdate)
    void FixedUpdate()
    {
        // Перетворюємо 2D ввід (X, Y) у 3D вектор (X, 0, Z)
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * speed;

        // Зберігаємо поточну вертикальну швидкість (щоб не ламати гравітацію), змінюємо лише X та Z
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    // 3. Логіка Тригера (зміна кольору)
    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи увійшли ми саме в нашу зону (можна перевіряти по тегу або імені)
        if (other.gameObject.name == "TriggerZone")
        {
            playerRenderer.material.color = Color.green; // Змінюємо колір на зелений
            Debug.Log("Entered Trigger Zone!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TriggerZone")
        {
            playerRenderer.material.color = originalColor; // Повертаємо колір назад
            Debug.Log("Exited Trigger Zone!");
        }
    }
}
