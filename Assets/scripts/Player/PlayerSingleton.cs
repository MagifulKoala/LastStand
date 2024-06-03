using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton Instance{get; private set;}
    public Transform playerTransform;
    public float playerScore;

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

    private void OnEnable()
    {
        playerScore = 0;    
    }

    public Transform getTransform()
    {
        //Debug.Log("getting transform");
        return playerTransform;
    }

    public void UpdateScore(float pNewScore)
    {
        playerScore += pNewScore;
        UIControl.Instance.UpdateScore(playerScore);
    }

}
