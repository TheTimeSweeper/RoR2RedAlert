using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nopejs : MonoBehaviour
{
    [SerializeField]
    private float multiplier = 10;

    [SerializeField]
    private Vector3 rotation = Vector3.up;

    private void Update()
    {
        transform.Rotate(rotation * multiplier * Time.deltaTime);
    }
}
