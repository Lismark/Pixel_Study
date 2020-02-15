using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField]private GameObject volumeImg;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    private int volume;
    private void Start()
    {
        
    }
    public void SoundToggle()
    {

        volume = PlayerPrefs.GetInt("volume");
        if (volume < 1)
        {
            PlayerPrefs.SetInt("volume", 1);
            volumeImg.GetComponent<Image>().sprite = onSprite;

        }
        else
        {
            PlayerPrefs.SetInt("volume", 0);
            volumeImg.GetComponent<Image>().sprite = offSprite;
        }
        Debug.Log(PlayerPrefs.GetInt("volume"));
    }
}
