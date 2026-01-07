using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private float smoothSpeed = 8f;
    [SerializeField] private Vector2 deadZoneSize = new Vector2(2f, 1.5f);
    [SerializeField] private Vector3 offset;

    private Vector3 anchorPosition;

    private void Start()
    {
        anchorPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPos = target.position + offset;

        float deltaX = targetPos.x - anchorPosition.x;
        float deltaY = targetPos.y - anchorPosition.y;

        if (Mathf.Abs(deltaX) > deadZoneSize.x)
        {
            anchorPosition.x = targetPos.x - Mathf.Sign(deltaX) * deadZoneSize.x;
        }

        if (Mathf.Abs(deltaY) > deadZoneSize.y)
        {
            anchorPosition.y = targetPos.y - Mathf.Sign(deltaY) * deadZoneSize.y;
        }

        anchorPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            anchorPosition,
            smoothSpeed * Time.deltaTime
        );
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(anchorPosition, new Vector3(deadZoneSize.x * 2, deadZoneSize.y * 2, 0));
    }
#endif
}