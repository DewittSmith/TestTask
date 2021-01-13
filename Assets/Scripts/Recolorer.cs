using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Recolorer : MonoBehaviour
{
    private SpriteRenderer renderer;
    private void Awake() => renderer = GetComponent<SpriteRenderer>();

    public void Recolor(Color color) => renderer.color = color;
}
