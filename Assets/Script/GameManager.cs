using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
   
    [SerializeField] int vegetablesChopped = 0;
    [SerializeField] int vegetablesPlaced = 0;
    [SerializeField] int totalVegetables = 10;
     
    private float gameTime = 0f;
    public bool gameActive = true;
    
    
    private UIManager uiManager;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        
        if (uiManager != null)
        {
            uiManager.UpdateVegetableCount(vegetablesChopped, totalVegetables);
        }
    }
    
    void Update()
    {
        if (gameActive)
        {
            gameTime += Time.deltaTime;

            uiManager?.UpdateTimer(gameTime);
            
            if (vegetablesPlaced >= totalVegetables)
            {
                EndGame();
            }
        }
    }
    
    public void AddChoppedVegetable()
    {
        vegetablesChopped++;
        
        if (uiManager != null)
        {
            uiManager.UpdateVegetableCount(vegetablesChopped, totalVegetables);
        }
        
        Debug.Log("Vegetables chopped: " + vegetablesChopped);
    }
    
    public void VegetablePlaced()
    {
        vegetablesPlaced++;
        
        if (uiManager != null)
        {
            uiManager.UpdateProgress((float)vegetablesPlaced / totalVegetables);
        }
        
        Debug.Log("Vegetables placed: " + vegetablesPlaced);
    }
    
    void EndGame()
    {
        gameActive = false;
        
        if (uiManager != null)
        {
            uiManager.ShowGameComplete(gameTime);
        }
        
        Debug.Log("Game Complete! Time: " + gameTime.ToString("F2") + " seconds");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}