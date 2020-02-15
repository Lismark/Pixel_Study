using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    private Health playerHealth;
    [SerializeField] private Image healthImage;
    private float maxHealth;
    
    void Start()
    {
       playerHealth = player.GetComponent<Health>();
       maxHealth = playerHealth.PHealth;
    }

    
    void Update()
    {
        healthImage.fillAmount = playerHealth.PHealth / maxHealth;
    }
}
