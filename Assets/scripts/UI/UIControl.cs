using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider healthBar;
    public TMP_Text healthText;
    public TMP_Text score;
    public StatsControl playerstatsControl;
    public static UIControl Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        healthBar.value = 1;
        healthText.text = "100/100";
        score.text = "0";
        playerstatsControl.playerDied.AddListener(PlayerDied);
    }

    private void PlayerDied()
    {
        MainLevel.Instance.EndRun();
    }

    public void UpdateHealthBar(float pNewHealth, float pMaxHealth)
    {
        healthBar.value = (float)(pNewHealth)/(float)(pMaxHealth);
        healthText.text = $"{pNewHealth}/{pMaxHealth}";
    }

    public void UpdateScore(float pNewScore)
    {
        score.text = $"{pNewScore}";
    }

}
