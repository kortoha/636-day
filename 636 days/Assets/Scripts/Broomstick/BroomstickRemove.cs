using UnityEngine;

public class BroomstickRemove : MonoBehaviour
{
    [SerializeField] private Collider[] _spawnArea;
    [SerializeField] private GameObject _timer;

    public int broomsticksCount { get; private set; } = 0;

    private void Update()
    {
        if (broomsticksCount == 5)
        {
            gameObject.SetActive(false);
            _timer.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Remove();
            broomsticksCount++;
            Debug.Log(broomsticksCount);
        }
    }

    public void Remove()
    {
        Collider randomCollider = _spawnArea[UnityEngine.Random.Range(0, _spawnArea.Length)];

        Vector3 randomPointLocal = new Vector3(
            UnityEngine.Random.Range(randomCollider.bounds.min.x, randomCollider.bounds.max.x),
            0f,
            UnityEngine.Random.Range(randomCollider.bounds.min.z, randomCollider.bounds.max.z));

        Vector3 randomPointWorld = randomCollider.transform.TransformPoint(randomPointLocal);

        Vector3 randomPointLocalAgain = randomCollider.transform.InverseTransformPoint(randomPointWorld);

        transform.localPosition = randomPointLocalAgain;
    }

    private void OnEnable()
    {
        Remove();
        broomsticksCount = 0;
    }
}