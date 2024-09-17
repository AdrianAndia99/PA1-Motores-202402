using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    public float speed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded;
    public float maxHealth = 100f;
    private float currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded && context.performed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
        if (collision.gameObject.CompareTag("InstaKill"))
        {
            SceneManager.LoadScene("Derrota");
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Derrota");
            Debug.Log("El personaje ha muerto.");
        }
    }
}