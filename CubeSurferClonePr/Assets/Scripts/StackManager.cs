using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Cubes = new List<GameObject>();
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject _GameOver;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cubeStack"))
        {
            other.gameObject.transform.SetParent(transform); //gelen objenin transformunu benim transformum yap.
            other.gameObject.GetComponent<BoxCollider>().enabled = false; //çarptığımız küplerin aktifliğini kapattık.
            other.gameObject.transform.localPosition = new Vector3(0f, _Cubes[_Cubes.Count - 1].transform.localPosition.y + 1f, 0f);
            _Cubes.Add(other.gameObject);
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y +1 , character.transform.position.z);
        }

        if (other.CompareTag("obstacle")) //engele çarptığımda
        {
            
            Obstacles script= other.GetComponent<Obstacles>();

            if (_Cubes.Count - 1 > script.height)
            {
                for (int i = script.height + 1; i > 0; i--) //karakterin küplerinden engelin yüksekliği kadar düşürülür. küpümün yüksekliği kadar for dönüyor.
                {
                    Destroy(_Cubes[_Cubes.Count-i]); //i'nin sayısı neyse onu siliyor.
                    _Cubes.Remove(_Cubes[_Cubes.Count - i]);//listenin elemanlarını azalttık.

                }
                character.transform.position = new Vector3(character.transform.position.x,_Cubes.Count+0.5f , character.transform.position.z);
            }
            else
            {
                _GameOver.SetActive(true);
                StartCoroutine(Fade());
            }

            
        }
        
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.3f);
        Time.timeScale = 0;


    }
}
