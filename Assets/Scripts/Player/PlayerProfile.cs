using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerProfile", menuName = "Scriptable Objects/Player Profile", order = 1)]

public class PlayerProfile : ScriptableObject
{
    // Puntos de experiencia para llegar al siguiente nivel
    [Header("Configuraciones de Progresión de Experiencia")]
    
    [SerializeField]
    [Tooltip("Rango de experience necesaria para el proximo level")]
    [Range(10, 50)]
    private int expNextLevel;
    public int ExpNextLevel { get => expNextLevel; set => expNextLevel = value; }

    // Escala de los puntos de experiencia
    [SerializeField]
    [Tooltip("Como aumenta la experienca de nivel a nivel")]
    [Range(10, 2000)]
    private int expScale;
    public int ExpScale { get => expScale; set => expScale = value; }

    // Nivel del jugador
    private int level = 1;
    public int Level { get => level; set => level = value; }

    // Experiencia
    private int experience = 0;
    public int Experience { get => experience; set => experience = value; }

    // Configuraciones de Movimiento (salto y velocidad)
    [Header("Configuraciones de Movimiento")]

    [SerializeField]
    [Tooltip("Velocidad de correr")]
    private float runSpeed = 2f;
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }

    [SerializeField]
    [Tooltip("Velocidad del salto")]
    private float jumpSpeed = 3f;
    public float JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }

    [SerializeField]
    [Tooltip("Si se activa, el personaje salta de acuerdo a qué " +
             "tan presionado esté el botón de salto")]
    private bool betterJump = false;
    public bool BetterJump { get => betterJump; set => betterJump = value; }

    [SerializeField]
    [Tooltip("Como aumenta la gravedad de la caída " +
        "(Sólo si Better Jump está activado)")]
    private float fallMultiplier = 0.5f;
    public float FallMultiplier { get => fallMultiplier; set => fallMultiplier = value; }

    [SerializeField]
    [Tooltip("Como aumenta la gravedad del salto " +
        "(Sólo si Better Jump está activado)")]
    private float lowJumpMultiplier = 1f;
    public float LowJumpMultiplier { get => lowJumpMultiplier; set => lowJumpMultiplier = value; }

    // Configuraciones de efectos de sonido
    [Header("Configuraciones SFX")]
    
    [SerializeField] private AudioClip jumpSFX;
    public AudioClip JumpSFX { get => jumpSFX; }

    [SerializeField] private AudioClip collisionSFX;
    public AudioClip CollisionSFX { get => collisionSFX; }

}
