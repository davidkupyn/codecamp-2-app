using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpSpeed = 5f;
    void LateUpdate()
    {
        Vector3 targetPosition = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
