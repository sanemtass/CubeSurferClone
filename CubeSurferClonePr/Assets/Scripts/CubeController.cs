using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float speedZ;
    [SerializeField] private float speedX;

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * speedX * Time.deltaTime;
        this.transform.Translate(xAxis, 0f, speedZ * Time.deltaTime);
    }
   

}