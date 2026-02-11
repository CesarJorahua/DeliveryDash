using UnityEngine;
using UnityEngine.InputSystem;
using DeliveryDash.Core.Input;

public class Driver : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float steerSpeed = 5f;

    private InputSystemActions inputActions;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        inputActions = new InputSystemActions();
        inputActions.Player.Enable();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();        
        rb2D.linearVelocity = transform.up * moveSpeed * moveInput.y * Time.deltaTime;
        rb2D.angularVelocity = -steerSpeed * moveInput.x * Time.deltaTime;
    }
    
    private void OnDestroy()
    {
        //inputActions.Player.Move.performed -= ProcessInput;
        inputActions.Player.Disable();
    }
}
