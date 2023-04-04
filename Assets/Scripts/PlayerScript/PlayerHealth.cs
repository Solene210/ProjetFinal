using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    #region Expose
    public static PlayerHealth Instance;
    public int health = 5;
    public int gemme = 0;
    public Quest quest;
    public TextMeshProUGUI healthText;
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
        healthText.text = $"HP : {health}";
    }
    private void Update()
    {
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
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    #endregion

    public bool _allowLavaDamage;
    public float _lavaDamageTickTime = 1f;
    private float _lavaDamageTimer;
    private bool _isTimerOn;
}
