using UnityEngine;

public class TrashBasket_Visual : MonoBehaviour
{
    private const string OPEN_POS = "IsOpen";

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _trashPanel;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_player.isCarrying)
        {
            _animator.SetBool(OPEN_POS, false);
            _trashPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && _player.isCarrying)
        {
            _animator.SetBool(OPEN_POS, true);
            _trashPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && _player.isCarrying)
        {
            _animator.SetBool(OPEN_POS, false);
            _trashPanel.SetActive(false);
        }
    }
}
