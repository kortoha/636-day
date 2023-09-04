using UnityEngine;

public class SetMealOnTable : MonoBehaviour
{
    [SerializeField] private GameObject _tablePanel;
    [SerializeField] private Transform[] _tableTakePosition;
    [SerializeField] private Player _player;
    private Transform _carriedBox;
    private int _positionIndex = 0;

    private void Update()
    {
        if (!_player.isCarrying)
        {
            _tablePanel.SetActive(false);
        }

        if(_positionIndex == 3)
        {
            _tablePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player.isCarrying)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _tablePanel.SetActive(true);
            }
        }
        else
        {
            _tablePanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_player.isCarrying)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _tablePanel.SetActive(false);
            }
        }
        else
        {
            _tablePanel.SetActive(false);
        }
    }

    public void SetCarriedBox(Transform box)
    {
        _carriedBox = box;
    }

    public void PlaceBoxOnTableButton()
    {
        if (_carriedBox != null && _positionIndex >= 0 && _positionIndex < _tableTakePosition.Length)
        {
            _carriedBox.transform.parent = null;
            _carriedBox.transform.position = _tableTakePosition[_positionIndex].position;
            _carriedBox = null;
            _player.isCarrying = false;
            _positionIndex++;
        }
    }
}