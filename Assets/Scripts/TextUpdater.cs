using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextUpdater : MonoBehaviour
{
    public static UintEvent OnCollect = new UintEvent();

    private uint totalResources;

    [SerializeField] private string prefix = "Gold: ";

    private Text text;

    private void Awake() => text = GetComponent<Text>();

    private void OnEnable() => OnCollect.AddListener(UpdateText);
    private void OnDisable() => OnCollect.RemoveListener(UpdateText);

    private void Start() => OnCollect.Invoke(0);

    public void UpdateText(uint value)
    {
        totalResources += value;
        text.text = prefix + totalResources;
    }

}
