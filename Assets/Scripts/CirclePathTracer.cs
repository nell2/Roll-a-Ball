using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePathTracer : MonoBehaviour
{
    private Vector3 center = new Vector3(0.0F, 0.0F, 0.0F);

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center, Vector3.up, 45 * Time.deltaTime);
    }
}
