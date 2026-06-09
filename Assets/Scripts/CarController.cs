using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private InputSystem_Actions input;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float deathThreshold = -2.0f;
    private bool moveLeft = true;

    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Tap.started += ctx => PlayerTapped();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if (!GameManager.instance.isGameStarted) return;

        CheckDeath();
        MoveForward();
    }

    private void CheckDeath()
    {
        if (transform.position.y <= deathThreshold)
        {
            GameManager.instance.GameOver();
        }
    }

    private void MoveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void PlayerTapped()
    {
        if (GameManager.instance.isGameStarted)
        {
            ChangeDirection();
        }
        else
        {
            GameManager.instance.GameStart();
        }
    }

    private void ChangeDirection()
    {
        if (moveLeft)
        {
            moveLeft = false;
            transform.rotation = Quaternion.Euler(0,90f,0);
        }
        else
        {
            moveLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
