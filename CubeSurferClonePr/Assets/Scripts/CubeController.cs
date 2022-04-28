using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float speedZ;
    [SerializeField] private float speedX;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * speedX * Time.deltaTime;
        transform.Translate(x, 0, speedZ * Time.deltaTime);
    }
}
