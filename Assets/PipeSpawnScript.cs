using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private float spawnRate = 2;
    private float timer = 0;
    [SerializeField]
    private float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        (float min, float max) pipeLimits = pipeHeightLimits();

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(pipeLimits.min, pipeLimits.max)), transform.rotation);
    }

    (float min, float max) pipeHeightLimits()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        return (lowestPoint, highestPoint);
    } 
}
