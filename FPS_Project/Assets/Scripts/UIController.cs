using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Slider healthSlider;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] public TextMeshProUGUI ammoText;
    [SerializeField] Image damageEffect;
    [SerializeField] float damageAlpha = .25f, damageFadeSpeed = 2f;
    //public Image blackScreen;
    public float fadeSpeed = 1.5f;

    public GameObject pauseScreen;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(damageEffect.color.a != 0) 
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime)); 
        }

        //if (!FPS_GameManager.instance.levelEnding)
        //{
        //    blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        //}
        //else
        //{
        //    blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        //}
    }

    public void ShowDamage()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, .25f);
    }
}
