using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth;
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;
    LevelManager levelManager;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start() {
        PlayerPrefs.SetString("currentScore","0");
    }


    float GetHpPerc(){
        return currentHealth / maxHealth;
    }

    public float RemainingHealthPercentage{
        get{
            return currentHealth / maxHealth;
        }
    }

    public void TakeDamage(int damageAmount){
        if(currentHealth == 0){
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if(currentHealth < 0){
            currentHealth = 0;
        }

        if(currentHealth == 0){
            OnDied.Invoke();
            PlayerPrefs.SetString("currentScore",scoreKeeper.scoreText.text);
            levelManager.LoadGameOver();
        }
        else{
            OnDamaged.Invoke();
        }
    }
}
