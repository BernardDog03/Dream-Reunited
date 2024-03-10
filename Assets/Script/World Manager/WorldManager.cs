using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour
{
    public UnityEvent OnTriggerEnterWorld;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.CompareTag("Go2ndFloorHouse"))
        {
            OnTriggerEnterWorld.Invoke();
        }
        else if(gameObject.CompareTag("Go1stFloorHouse"))
        {
            OnTriggerEnterWorld.Invoke();
        }
        else if(gameObject.CompareTag("LoadSave"))
        {
            OnTriggerEnterWorld.Invoke();
        }
    }
}
