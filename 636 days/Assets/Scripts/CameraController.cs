using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _camera.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _camera.SetActive(false);
        }
    }
}