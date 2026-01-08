using Assets.Projekt.Scripts.Core.Player;
using Assets.Projekt.Scripts.System.Auras;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AuraController auraController;

    private PlayerMovement movement;
    private PlayerStamina stamina;
    private PlayerRoll roll;

    private Vector2 moveInput;
    private PlayerInputActions input;

    public PlayerStamina Stamina => stamina;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody2D>();

        movement = new PlayerMovement(rb, 6f);
        stamina = new PlayerStamina(100f, 20f, 0.5f);

        roll = new PlayerRoll(rb, this, 14f, 0.25f, 0.5f, 0.08f);
        roll.OnPerfectDodge += () =>
            auraController.AddAura(new MomentumAura(1f));

        input = new PlayerInputActions();
        input.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Gameplay.Move.canceled += _ => moveInput = Vector2.zero;
        input.Gameplay.Roll.performed += _ =>
        {
            if (stamina.CanSpend(25f))
            {
                stamina.Spend(25f);
                roll.TryRoll(moveInput);
            }
        };
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        stamina.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (!roll.IsRolling)
        {
            movement.Move(moveInput);
        }
    }

    public void TryTakeHit()
    {
        // 1. Sprawdź perfect dodge
        roll.TryPerfectDodge();

        // 2. Jeśli roll był perfect → NIE dostajesz hita
        if (roll.IsRolling)
            return;

        Debug.Log("PLAYER HIT");
    }

}
