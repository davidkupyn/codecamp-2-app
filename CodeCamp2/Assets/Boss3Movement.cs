using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : MonoBehaviour
{
    public float speed;


    [SerializeField] private Transform Player;
    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, Player.transform.position, 5f * Time.deltaTime);

        newPosition.x = transform.position.x;
        newPosition.z = transform.position.z;

        transform.position = newPosition;
    }
}