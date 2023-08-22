using UnityEngine;

public class ChallangeVisual : MonoBehaviour
{
    [SerializeField] private GameObject _challangeButoon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _challangeButoon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _challangeButoon.SetActive(false);
        }
    }
}
