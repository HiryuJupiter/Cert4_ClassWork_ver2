using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [Header("Scene")]
    [SerializeField] public int sceneIndex = 1;

    [Header("World")]
    [SerializeField] public Vector3 position = Vector3.zero;

    [Header("PlayerStats")]
    [SerializeField] public float walkSpeed = 6f;
    [SerializeField] public float sprintSpeed = 20f;
    [SerializeField] public float crouchSpeed = 3f;
    [SerializeField] public float jumpHeight = 1f;

    [SerializeField] public int level = 1;

    [SerializeField] public int currentHealth = 100;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentMana = 100;
    [SerializeField] public int maxMana = 100;
    [SerializeField] public int currentStamina = 100;
    [SerializeField] public int maxStamina = 100;
}
