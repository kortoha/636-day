using UnityEngine;

public class CarryingMealBox : MonoBehaviour
{

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private SetMealOnTable _tableScript;
    [SerializeField] private Player _player;

    public void CreateProduct(KitchenObjectSO meal)
    {
        if (!_player.isCarrying)
        {
            Transform productPrefab = null;

            productPrefab = meal.prefab;
            

            if (productPrefab != null)
            {
                Transform product = Instantiate(productPrefab, _spawnPoint.position, Quaternion.identity);
                product.transform.parent = _spawnPoint;
                _player.isCarrying = true;
                _tableScript.SetCarriedBox(product);
            }
        }
    }
}