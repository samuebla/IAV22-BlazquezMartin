using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position + target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
