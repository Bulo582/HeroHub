using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float activeTime = 0.2f;
    private EnemyHitbox hitbox;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private void Awake()
    {
        hitbox = GetComponentInChildren<EnemyHitbox>();

        if (hitbox == null)
        {
            Debug.LogError("EnemyAttack: EnemyHitbox NOT FOUND in children!", this);
        }
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);
            hitbox.Enable();
            yield return new WaitForSeconds(activeTime);
            hitbox.Disable();
        }
    }
}
