using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MoveObjectAsync : MonoBehaviour
{
    public float smoothing = 1f;
    public Transform destination;
    public Transform originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(transform.position, destination.position) > 0.05f)
            {
                moveObject(destination);
            }
            else
            {
                moveObject(originalPosition);
            }
        }
    }

    async void moveObject(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            await Task.Yield();
        }

        print("Reached the target.");

        await Task.Delay(3000);

        print("Async/Await is finished.");
    }
}
