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
    [Header("Death Parameter")]
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
            if (_lavaDamageTimer >= _lavaDamageTickTime)
            {
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
    #endregion

    public bool _allowLavaDamage;
    public float _lavaDamageTickTime = 1f;
    private float _lavaDamageTimer;
    private bool _isTimerOn;
}
