using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {
    public static GameInput Instance { get; private set; }
    private PlayerInput playerInput;

    public event EventHandler OnPlayerAttack;

    private void Awake() {

        Instance = this;
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Combat.Attack.started += PlayerAttack_started;

    }

    public void PlayerAttack_started(InputAction.CallbackContext obj) {

        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetVector() {
        return playerInput.Player.Move.ReadValue<Vector2>();
    }

    public Vector3 GetMousePosition() {
        Vector3 mPos = Mouse.current.position.ReadValue();
        return mPos;
    }
}
