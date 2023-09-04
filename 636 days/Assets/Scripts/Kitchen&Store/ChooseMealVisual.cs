using UnityEngine;

public class ChooseMealVisual : MonoBehaviour
{
    [SerializeField] private GameObject _mealPanel;
    [SerializeField] private Player _player;

    private void Update()
    {
        if (_player.isCarrying)
        {
            _mealPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_player.isCarrying)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _mealPanel.SetActive(true);
            }
        }
        else
        {
            _mealPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_player.isCarrying)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _mealPanel.SetActive(false);
            }
        }
        else
        {
            _mealPanel.SetActive(false);
        }
    }
}
