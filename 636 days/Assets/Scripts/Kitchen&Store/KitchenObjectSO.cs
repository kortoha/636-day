using UnityEngine;

[CreateAssetMenu]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Transform afterInteract;
    public float interactTime;
    public Sprite sprite;
    [SerializeField] private string _objectName;
}
