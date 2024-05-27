using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton Instance{get; private set;}

    private void Awake()
    {
        //Debug.Log("instance created");
        //Debug.Log($"transform: {transform} , {getTransform()}");    
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Transform getTransform()
    {
        //Debug.Log("getting transform");
        return transform;
    }

}
