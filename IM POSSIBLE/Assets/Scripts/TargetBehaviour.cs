using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public Vector3[] positions;
    public float[] times;

    public TargetBehaviour(Vector3[] pos, float[] tim)
    {
        positions = pos;
        times = tim;
    }

    private void Awake()
    {
        positions = new Vector3[10];
        times = new float[10];
        for (int i = 0; i < 10; i++)
        {
            positions[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            times[i] = Random.Range(1f, 2f);
        }
    }
    private void Start()
    {
        
    }
}
