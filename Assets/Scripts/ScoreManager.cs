using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int _score;
    private int _lastScore;
    private void Update()
    {
        if (_score == _lastScore) return;
        Debug.Log(_score);
        _lastScore = _score;
    }
}
