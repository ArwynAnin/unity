using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int _score;
    private int _lastScore;
    private TMP_Text _scoreBoard;

    private void Awake()
    {
        _scoreBoard = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_score == _lastScore) return;
        _scoreBoard.SetText("Score: " + _score.ToString());
        Debug.Log(_score);
        _lastScore = _score;
    }
}
