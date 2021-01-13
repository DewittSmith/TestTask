using System.Collections;
using UnityEngine;

public class MinerResizer : Resizer
{
    [Space(20)] [SerializeField] private float sizeDecayTime = 0.2f;
    [SerializeField] private Vector3 minedSize = Vector3.one;

    public void ApplyExtraSize() => StartCoroutine(ApplySize());

    private IEnumerator ApplySize()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / sizeDecayTime)
        {
            extraSize = Vector3.Lerp(minedSize, Vector3.zero, t);
            yield return null;
        }

        extraSize = Vector3.zero;
    }
}