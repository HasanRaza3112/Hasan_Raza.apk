using UnityEngine;

public class Vegetable : MonoBehaviour
{
   
    public bool isChopped = false;
    
    [SerializeField] GameObject choppedPrefab;
    
    [SerializeField] Transform platePosition;
    [SerializeField] float moveToPlateSpeed = 3f;
    private bool movingToPlate = false;
    
    private Renderer objectRenderer;
    
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }
    
    void Update()
    {
        
        if (isChopped && !movingToPlate)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                StartMovingToPlate();
            }
        }
        
        if (movingToPlate && platePosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, platePosition.position, moveToPlateSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, platePosition.position) < 0.1f)
            {
                movingToPlate = false;
                
                GameManager gameManager = FindFirstObjectByType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.VegetablePlaced();
                }
            }
        }
    }
    
    public void ChopVegetable()
    {
        if (isChopped) return;
        
        isChopped = true;
        
        
        if (choppedPrefab != null)
        {
            GameObject pieces = Instantiate(choppedPrefab, transform.position, Quaternion.identity);
            Destroy(pieces, 2f); 
            
        }
        
        transform.localScale *= 0.8f;

        Debug.Log("Vegetable chopped!");
        
        Destroy(this.gameObject, 2f);
    }
    
    void StartMovingToPlate()
    {
        movingToPlate = true;
        
        SoundManager soundManager = FindFirstObjectByType<SoundManager>();
        if (soundManager != null)
        {
            soundManager.PlayMoveSound();
        }
    }
}