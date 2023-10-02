using UnityEngine;

public class Play : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
