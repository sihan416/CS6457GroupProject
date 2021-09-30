using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableController : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // this/DestroySelf are just for testing/demo the destroy -> drop coin interaction
        // Invoke("DestroySelf", 2f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        // init coin
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.Euler(90, 90, 0)) as GameObject;
    }
}
