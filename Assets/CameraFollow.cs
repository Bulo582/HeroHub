using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private float smoothSpeed = 8f;
    [SerializeField] private Vector2 deadZoneSize = new Vector2(2f, 1.5f);
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = transform.position;
        Vector3 targetPosition = target.position + offset;

        float deltaX = targetPosition.x - transform.position.x;
        float deltaY = targetPosition.y - transform.position.y;

        if (Mathf.Abs(deltaX) > deadZoneSize.x)
        {
            desiredPosition.x = targetPosition.x - Mathf.Sign(deltaX) * deadZoneSize.x;
        }

        if (Mathf.Abs(deltaY) > deadZoneSize.y)
        {
            desiredPosition.y = targetPosition.y - Mathf.Sign(deltaY) * deadZoneSize.y;
        }

        desiredPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(deadZoneSize.x * 2, deadZoneSize.y * 2, 0));
    }
#endif
}