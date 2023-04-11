using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Expose
    public static PlayerHealth Instance;
    [Header("Health Parameter")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 5;
    [SerializeField] private Image _healthbar;
    [SerializeField] private TextMeshProUGUI healthText;
    [Header("Death/Damage Parameter")]
    [SerializeField] private GameObject damagePanel;
    [SerializeField] private GameObject gameOverPanel;
    public UnityEvent _damageReceived;
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        Instance = this;
        _allowLavaDamage = true;
        _isTimerOn = false;
        _lavaDamageTimer = 0;
    }

    void Start()
    {
        health = maxHealth;
        healthText.text = $"HP : {health}";
    }
    private void Update()
    {
        _healthbar.fillAmount = health / maxHealth;
        if(_isTimerOn)
        {
            _lavaDamageTimer += Time.deltaTime;
            damagePanel.SetActive(true);
           
            //StartCoroutine(coroutine());
            if (_lavaDamageTimer >= _lavaDamageTickTime)
            {
                damagePanel.SetActive(false);
                //StopCoroutine(coroutine());
                _allowLavaDamage = true;
                _isTimerOn = false;
                _lavaDamageTimer = 0;
            }
        }
    }
    #endregion

    #region methods
    public void DecreaseHealth(int value)
    {
        health -= value;
        healthText.text = $"HP : {health}";
        _damageReceived.Invoke();
        if (health == 0)
        {
            GameOver();
        }
    }

    public void ApplyLavaDamage(int damage)
    {
        if (_allowLavaDamage)
        {
            _isTimerOn = true;
            DecreaseHealth(damage);
            _allowLavaDamage = false;
        }
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        healthText.text = $"HP : {health}";
    }

    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    IEnumerator coroutine()
    {
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(1f);
            damagePanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            damagePanel.SetActive(false);
        }

        //float blinkSpeed = 0.2f; // La vitesse à laquelle le texte clignote
        //float blinkTime = 0; // Le temps écoulé depuis le dernier clignotement
        //bool blink = false; // Indique si le texte doit être visible ou non
        //damagePanel.SetActive(false);

        //for (int i = 0; i < 400; i++)
        //{
        //    blinkTime += Time.deltaTime;

        //    // Clignoter le texte
        //    if (blinkTime >= blinkSpeed)
        //    {
        //        Debug.Log("BOUCLE FOR IF");
        //        blink = !blink;
        //        damagePanel.SetActive(true);
        //        blinkTime = 0;
        //    }

        //    yield return null;
        //}
        //damagePanel.SetActive(false);
    }
    #endregion

    public bool _allowLavaDamage;
    public float _lavaDamageTickTime = 1f;
    private float _lavaDamageTimer;
    private bool _isTimerOn;
}
