using UnityEngine;

public class HandMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float verticalRange = 3f;
    public float horizontalRange = 4f;
    
    private Vector3 startPosition;
    private bool isChopping = false;
    
    public float choppingSpeed = 10f;
    private Vector3 targetChopPosition;
    
    void Start()
    {
        
        startPosition = transform.position;
    }
    
    void Update()
    {
        HandleMovement();
        HandleChopping();
    }
    
    void HandleMovement()
    {
        
        float horizontalInput = -Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");     
        
        
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        
        newPosition.x = Mathf.Clamp(newPosition.x, startPosition.x - horizontalRange, startPosition.x + horizontalRange);
        newPosition.y = Mathf.Clamp(newPosition.y, startPosition.y - verticalRange, startPosition.y + verticalRange);
        
        transform.position = newPosition;
    }
    
    void HandleChopping()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && !isChopping)
        {
            StartChopping();
        }
        
        
        if (isChopping)
        {
            transform.position = Vector3.Lerp(transform.position, targetChopPosition, choppingSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetChopPosition) < 0.1f)
            {
                isChopping = false;
            }
        }
    }
    
    void StartChopping()
    {
        isChopping = true;
        targetChopPosition = transform.position + Vector3.down * 0.5f;
        
        SoundManager soundManager = FindFirstObjectByType<SoundManager>();
        if (soundManager != null)
        {
            soundManager.PlayChopSound();
        }
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vegetable") && isChopping)
        {
            Vegetable veg = other.GetComponent<Vegetable>();
            if (veg != null && !veg.isChopped)
            {
                veg.ChopVegetable();
                
                GameManager gameManager = FindFirstObjectByType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.AddChoppedVegetable();
                }
            }
        }
    }
}