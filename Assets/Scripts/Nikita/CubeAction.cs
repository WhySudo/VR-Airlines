using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAction : MonoBehaviour
{
    [SerializeField]
    private float ratio = 2f;
    
    [SerializeField]
    private int limit = 250;
    
    private int count = 0;
    private Vector3 moveType = Vector3.left;

    private void Awake() {
        count = limit / 2;
    }

    private void FixedUpdate()
    {
        count++;
        if (count > limit) {
            count = 0;
            moveType = -moveType;
        }

        transform.position += moveType * Time.deltaTime * ratio;
    }
}
