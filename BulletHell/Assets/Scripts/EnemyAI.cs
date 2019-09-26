﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] float xSize = 0.5f;
    [SerializeField] float ySize = 0.5f;
    [SerializeField] float xOffset = 0.5f;
    [SerializeField] float yOffset = 0.5f;
    [SerializeField] float xSpeed = 1f;
    [SerializeField] float ySpeed = 1f;
    [SerializeField] private GameObject enemySprite = null;
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Health")]
    [SerializeField] float enemyHealth = 200f;
    [SerializeField] Image healthBar;

    private Rigidbody2D _rbd;
    private float startHealth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rbd = gameObject.GetComponent<Rigidbody2D>();
        startHealth = enemyHealth;
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Mathf.Sin(Time.time * xSpeed) - xOffset * xSize, Mathf.Cos(Time.time * ySpeed)  - yOffset * ySize);
        _rbd.position = movement;

        Quaternion enemyRotate = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Sin(Time.time) * 2f * Mathf.Rad2Deg));
        enemySprite.transform.rotation = enemyRotate;

        FireRotation();
    }

    private void FireRotation()
    {
        float h = Mathf.Sin(Time.time);
        float v = Mathf.Cos(Time.time);
        float hv = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
        Vector3 rot = new Vector3(0f, 0f, hv);
        Quaternion rotation = Quaternion.Euler(rot);

        bulletSpawnPoint.rotation = rotation;

    }

    public void ApplyDamage(float damage)
    {
        enemyHealth--;
        healthBar.fillAmount = enemyHealth / startHealth;
        if(enemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
