using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Cubes = new List<GameObject>();
    [SerializeField] private GameObject character;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cubeStack"))
        {
            other.gameObject.transform.SetParent(transform); //gelen objenin transformunu benim transformum yap.
            other.gameObject.GetComponent<BoxCollider>().enabled = false; //çarptığımız küplerin aktifliğini kapattık.
            other.gameObject.transform.localPosition = new Vector3(0f, _Cubes[_Cubes.Count - 1].transform.localPosition.y + 1f, 0f);
            _Cubes.Add(other.gameObject);
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1, character.transform.position.z);
        }
    }
}
