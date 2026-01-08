using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    public void Enable() => col.enabled = true;
    public void Disable() => col.enabled = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out PlayerController player))
            return;

        player.TryTakeHit();
    }
}