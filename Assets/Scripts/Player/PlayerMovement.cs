using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;

    [SerializeField] private float movementSpeed = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * movementSpeed;
    }

    #region Handle inputs
    void OnMove(InputValue value) { movement = value.Get<Vector2>(); }
    #endregion
}
