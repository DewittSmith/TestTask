using UnityEngine;

public class Resizer  : MonoBehaviour
{
    [SerializeField] private float frequency = 1;
    [SerializeField] private float amplitude = 1;
    [SerializeField] private float randomTime = 3.14f;

    private float time;
    private Vector3 startSize;
    private protected Vector3 extraSize;

    private void Start()
    {
        startSize = transform.localScale;
        time = Random.value * randomTime;
    }

    private void Update()
    {
        time += Time.deltaTime;
        transform.localScale = startSize + Vector3.one * amplitude * (Mathf.Sin(time * frequency) + 1) * .5f + extraSize;
    }
}