using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer debugRenderer;

    private void Awake()
    {
        col = GetComponent<Collider2D>();

        if (debugRenderer == null)
            debugRenderer = GetComponent<SpriteRenderer>();

        col.enabled = false;
        UpdateDebugColor();
    }

    public void Enable()
    {
        col.enabled = true;
        UpdateDebugColor();
    }

    public void Disable()
    {
        col.enabled = false;
        UpdateDebugColor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out PlayerController player))
            return;

        player.TryTakeHit();
    }

    private void UpdateDebugColor()
    {
        if (debugRenderer == null)
            return;

        debugRenderer.color = col.enabled ? Color.yellow : Color.red;
    }
}