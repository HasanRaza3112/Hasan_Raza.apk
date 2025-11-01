using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text vegetableCountText;
    public TMP_Text timerText;
    
    public Slider progressBar;
    public GameObject gameCompletePanel;
    

    
    
    
    void Start()
    {
        if (gameCompletePanel != null)
        {
            gameCompletePanel.SetActive(false);
        }
        
      
    }
    
    
    public void UpdateVegetableCount(int chopped, int total)
    {
        if (vegetableCountText != null)
        {
            vegetableCountText.text = "Chopped: " + chopped + " / " + total;
        }
    }
    
    public void UpdateTimer(float time)
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }
    
    public void UpdateProgress(float progress)
    {
        if (progressBar != null)
        {
            progressBar.value = progress;
        }
    }
    
    
    public void ShowGameComplete(float finalTime)
    {
        if (gameCompletePanel != null)
        {
            gameCompletePanel.SetActive(true);
        }
       
    }
}