using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MinerResizer), typeof(Recolorer), typeof(Collider2D))]
public class Miner : MonoBehaviour, IMiner
{
    [SerializeField] private uint mineCount = 1;
    [SerializeField] private float mineDelay = 1;

    private UnityEvent OnMined = new UnityEvent();

    private uint collectedResource
    {
        get => collected;
        set
        {
            recolorer.Recolor(value == 0 ? Color.white : Color.yellow);
            collected = value;
        }
    }

    private uint collected;

    private MinerResizer resizer;
    private Recolorer recolorer;


    private void Awake()
    {
        resizer = GetComponent<MinerResizer>();
        recolorer = GetComponent<Recolorer>();
    }

    private void OnEnable() => OnMined.AddListener(resizer.ApplyExtraSize);

    private void OnDisable() => OnMined.RemoveListener(resizer.ApplyExtraSize);

    private void Start() => InvokeRepeating(nameof(Mine), mineDelay, mineDelay);

    private void OnMouseDown() => CollectResources();

    private void CollectResources()
    {
        TextUpdater.OnCollect.Invoke(collectedResource);
        collectedResource = 0;
    }

    public void Mine()
    {
        collectedResource += mineCount;
        OnMined.Invoke();
    }
}