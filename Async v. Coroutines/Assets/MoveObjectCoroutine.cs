using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCoroutine : MonoBehaviour
{
    public float smoothing = 1f;
    public Transform destination;
    public Transform originalPosition;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Vector3.Distance(transform.position, destination.position) > 0.05f)
            {
                StartCoroutine(moveObject(destination));
            }
            else
            {
                StartCoroutine(moveObject(originalPosition));
            }
        }
    }

    IEnumerator moveObject(Transform target)
    {
            while (Vector3.Distance(transform.position, target.position) > 0.05f)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

                yield return null;

            }

            print("Reached the target.");

            yield return new WaitForSeconds(3f);

            print("Corutine is finished");
    }
}
