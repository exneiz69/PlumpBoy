using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _movement;
    private PlayerControls _inputActions;

    #region MonoBehaviour

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Jump.performed += OnJumpPerform;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Jump.performed -= OnJumpPerform;
    }

    #endregion

    private void OnJumpPerform(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _movement.Jump();
    }
}
