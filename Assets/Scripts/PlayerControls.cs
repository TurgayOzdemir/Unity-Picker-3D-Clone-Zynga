using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private GameObject gameUI;

    private GameUI _gameUI;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _pauseAction;

    private Rigidbody _rb;


    private void Awake()
    {
        _gameUI = gameUI.GetComponent<GameUI>();

        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _pauseAction = _playerInput.actions["Pause"];
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        _rb.MovePosition(transform.position + new Vector3(input.x * Time.deltaTime ,0,verticalSpeed * Time.deltaTime));


    }

    private void OnEnable()
    {
        _pauseAction.performed += _ => pauseGame();
    }

    private void OnDisable()
    {
        _pauseAction.performed -= _ => pauseGame();
    }

    void pauseGame()
    {
        _gameUI.SetESCInput(true);
    }

    public void setVerticalSpeed(float newVerticalSpeed)
    {
        verticalSpeed = newVerticalSpeed;
    }
    public float getVerticalSpeed()
    {
        return verticalSpeed;
    }

}
