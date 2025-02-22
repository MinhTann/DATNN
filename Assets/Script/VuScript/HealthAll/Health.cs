using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float healingRate; // tốc độ hồi máu 0.1f/s
    [SerializeField] private float _currenHealth;

    void Start()
    {
        _currenHealth = maxHealth;
        StartCoroutine(Healing());
    }

    public float GetCurrenHealth() => _currenHealth;
    public float GetMaxHealth() => maxHealth;
    public void SetHealingRate(float rate) => healingRate = rate;

    public void TakeDamage(float damage)
    {
        _currenHealth -= damage;
    }

    // hàm hồi máu
    IEnumerator Healing()
    {
        while (true)
        {
            _currenHealth += healingRate * Time.deltaTime;
            _currenHealth = Mathf.Min(_currenHealth, maxHealth); // lấy phần tử nhỏ hơn
            yield return new WaitForSeconds(1);
        }
    }
}
