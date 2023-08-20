using UnityEngine;
using System.Collections;

public class TransparentWall : MonoBehaviour
{
    private Material _material;
    private Color _initialColor;
    private Color _transparentColor = new Color(1f, 1f, 1f, 0f); // Прозрачный цвет

    [SerializeField] private float _lerpSpeed = 2f; // Скорость изменения прозрачности

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _initialColor = _material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines(); // Остановка предыдущих корутин

            StartCoroutine(LerpColor(_transparentColor));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines(); // Остановка предыдущих корутин

            StartCoroutine(LerpColor(_initialColor));
        }
    }

    private IEnumerator LerpColor(Color targetColor)
    {
        float elapsedTime = 0f;
        Color startColor = _material.color;

        while (elapsedTime < _lerpSpeed)
        {
            _material.color = Color.Lerp(startColor, targetColor, elapsedTime / _lerpSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _material.color = targetColor;
    }
}