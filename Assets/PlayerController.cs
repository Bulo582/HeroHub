using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public System.Action OnPerfectDodge;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("Roll")]
    [SerializeField] private float rollSpeed = 14f;
    [SerializeField] private float rollDuration = 0.25f;
    [SerializeField] private float rollCooldown = 0.5f;
    private bool canRoll = true;

    [Header("I-Frames")]
    [SerializeField] private float invulnerableTime = 0.18f;
    [SerializeField] private float perfectDodgeWindow = 0.08f;

    private bool isInvulnerable;
    private bool perfectDodgeActive;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private PlayerInputActions inputActions;

    enum PlayerState
    {
        Normal,
        Rolling
    }
    private PlayerState currentState = PlayerState.Normal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        inputActions = new PlayerInputActions();
        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Gameplay.Roll.performed += _ => TryRoll();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {
        if (currentState != PlayerState.Normal)
            return;

        rb.velocity = moveInput * moveSpeed;
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            TryTakeHit();
        }
    }

    private void TryRoll()
    {
        if (!canRoll) return;
        if (currentState == PlayerState.Rolling) return;
        if (moveInput == Vector2.zero) return;

        StartCoroutine(RollCoroutine());
    }

    private System.Collections.IEnumerator RollCoroutine()
    {
        canRoll = false;
        currentState = PlayerState.Rolling;

        Vector2 rollDirection = moveInput.normalized;

        // I-frames start
        isInvulnerable = true;
        perfectDodgeActive = true;

        // Perfect dodge window
        yield return new WaitForSeconds(perfectDodgeWindow);
        perfectDodgeActive = false;

        float timer = 0f;
        while (timer < rollDuration)
        {
            rb.velocity = rollDirection * rollSpeed;
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        // I-frames end
        isInvulnerable = false;

        rb.velocity = Vector2.zero;
        currentState = PlayerState.Normal;

        yield return new WaitForSeconds(rollCooldown);
        canRoll = true;
    }

    public void TryTakeHit()
    {
        if (isInvulnerable)
        {
            if (perfectDodgeActive)
            {
                Debug.Log("PERFECT DODGE!");
                OnPerfectDodge?.Invoke();
            }

            return;
        }

        Debug.Log("PLAYER HIT");
    }

}
