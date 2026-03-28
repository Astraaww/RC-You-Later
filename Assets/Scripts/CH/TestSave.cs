using UnityEngine;

public class TestSave : MonoBehaviour
{
    void Start()
    {
        Timer.Step();
        Timer.Step();
        Timer.Step();
        Timer.Save();
    }
}
