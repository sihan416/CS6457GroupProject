using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float range = 4f;
    public float speed = 4f;
    public float direction = 1f;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movementZ = direction * speed * Time.deltaTime;
        float newZ = transform.position.z + movementZ;

        if (Mathf.Abs(newZ - initialPosition.z) > range)
        {
            direction *= -1;
        }
        else 
        {
            transform.Translate(new Vector3(0, 0, movementZ));
        }
        
    }
}
