using TMPro;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _startingMinutes = 0; 
    [SerializeField] private int _startingSeconds = 0;
    [SerializeField] private GameObject _timer;
    [SerializeField] private BroomstickRemove _broomstick;

    private int _currentMinutes;
    private int _currentSeconds;
    private TMP_Text _text;
    private Coroutine _timerStart;

    public static Timer Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private IEnumerator TimerWork()
    {
        _text = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        _currentMinutes = _startingMinutes;
        _currentSeconds = _startingSeconds;
        UpdateText();

        while (_currentMinutes > 0 || _currentSeconds > 0)
        {
            if (_currentSeconds == 0)
            {
                _currentMinutes--;
                _currentSeconds = 59;
            }
            else
            {
                _currentSeconds--;
            }

            UpdateText();
            yield return new WaitForSeconds(1);
        }


        if(_currentMinutes == 0 && _currentSeconds == 0)
        {
            _broomstick.gameObject.SetActive(false);
            _timer.SetActive(false);
            StopCoroutine(_timerStart);
        }
    }

    private void UpdateText()
    {
        _text.text = _currentMinutes.ToString("D2") + " : " + _currentSeconds.ToString("D2");
    }

    public void TimerStart()
    {
        if (_timerStart != null)
        {
            StopCoroutine(_timerStart);
        }

        _timer.SetActive(true);
        _timerStart = StartCoroutine(TimerWork());
        _broomstick.gameObject.SetActive(true);
    }
}