using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;

    [SerializeField] private float movementSpeed = 0.1f;

    void Update()
    {
        transform.position += new Vector3(movement.x, movement.y, 0) * movementSpeed * Time.deltaTime;
    }

    #region Handle inputs
    void OnMove(InputValue value) { movement = value.Get<Vector2>(); }
    #endregion
}
