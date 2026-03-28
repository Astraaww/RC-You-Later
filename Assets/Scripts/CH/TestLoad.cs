using UnityEngine;

public class TestLoad : MonoBehaviour
{
    void Start()
    {
        Timer.Load();
        for (int i = 0; i < Timer.StepsCount; i++)
        {
            Debug.Log(Timer.GetStepElapsedSeconds(i));
        }
    }
}
