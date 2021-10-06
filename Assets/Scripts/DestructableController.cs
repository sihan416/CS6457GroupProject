using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableController : MonoBehaviour
{
    public GameObject destroyed;
    public GameObject pickup;
    // Start is called before the first frame update
    void Start()
    {

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        GameObject debris = Instantiate(destroyed, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        for (var i = 0; i < debris.transform.childCount; i++)
        {
            GameObject debrisPiece = debris.transform.GetChild(i).gameObject;
            switch(Random.Range(0, 3))
            {
                case 2:
                    Destroy(debrisPiece);
                    break;
                default:
                    break;
            }

            Destroy(debrisPiece, 3f);
        }
        GameObject powerup = Instantiate(pickup, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
