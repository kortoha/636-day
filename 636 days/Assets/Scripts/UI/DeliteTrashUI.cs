using UnityEngine;

public class DeleteTrashUI : MonoBehaviour
{
    [SerializeField] private Transform _mealPosition;
    [SerializeField] private Player _player;

    public void DeleteBoxButton()
    {
        if (_mealPosition != null && _mealPosition.childCount > 0)
        {
            Transform child = _mealPosition.GetChild(0); 
            Destroy(child.gameObject);
            _player.isCarrying = false;
        }
    }
}