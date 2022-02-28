using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeDisariCikmama : MonoBehaviour
{
    private float _radius;

    Vector3 centerPosition;

    void Start()
    {
        _radius = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            centerPosition = new Vector3(0, transform.position.y, transform.position.z);

            float distance = Vector3.Distance(transform.position, centerPosition);

            if (distance > _radius)
            {
                Vector3 fromOriginToObject = transform.position - centerPosition;
                fromOriginToObject *= _radius / distance;
                transform.position = centerPosition + fromOriginToObject;
            }
        }
    }
}
