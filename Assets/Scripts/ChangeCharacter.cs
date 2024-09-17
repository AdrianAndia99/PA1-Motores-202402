using UnityEngine;
using UnityEngine.InputSystem;
public class ChangeCharacter : MonoBehaviour
{
    public GameObject[] objects;
    private int currentIndex = 0;

    void Start()
    {
        
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateNextObject();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActivatePreviousObject();
        }
    }

    public void ActivateNextObject()
    {
        objects[currentIndex].SetActive(false);

        currentIndex = (currentIndex + 1) % objects.Length;

        objects[currentIndex].SetActive(true);
    }

    public void ActivatePreviousObject()
    {
        objects[currentIndex].SetActive(false);

        currentIndex = (currentIndex - 1 + objects.Length) % objects.Length;

        objects[currentIndex].SetActive(true);
    }
}
