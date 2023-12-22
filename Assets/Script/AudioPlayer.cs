using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField][Range(0, 1)] float volume = 1.0f;
    [Header("dead big enemy")]
    [SerializeField] AudioClip deadBigClip;
    [SerializeField][Range(0, 1)] float deadBigvolume = 1.0f;
    [Header("dead small enemy")]
    [SerializeField] AudioClip deadsmallClip;
    [SerializeField][Range(0, 1)] float deadsmallvolume = 1.0f;
    [Header("dead enemy")]
    [SerializeField] AudioClip deadClip;
    [SerializeField][Range(0, 1)] float deadvolume = 1.0f;
    [Header("PickUp sound")]
    [SerializeField] AudioClip pickupClip;
    [SerializeField][Range(0, 1)] float pickupClipVolume = 1.0f;
    [Header("fire ball")]
    [SerializeField] AudioClip fireBallClip;
    [SerializeField][Range(0, 1)] float fireBallVolume = 1.0f;
    [Header("enemy hurt")]
    [SerializeField] AudioClip enemyHurtClip;
    [SerializeField][Range(0, 1)] float enemyHurtVolume = 1.0f;
    [Header("player hurt")]
    [SerializeField] AudioClip playerHurtClip;
    [SerializeField][Range(0, 1)] float playerHurtVolume = 1.0f;
    [Header("Shooting sword")]
    [SerializeField] AudioClip shootingSwordClip;
    [SerializeField][Range(0, 1)] float shootingSwordVolume = 1.0f;
    [Header("Shooting rock")]
    [SerializeField] AudioClip shootingRockClip;
    [SerializeField][Range(0, 1)] float shootingRockVolume = 1.0f;

    private void Awake()
    {
        mangeSelgalton();
    }
    void mangeSelgalton()
    {
        int instant = FindObjectsOfType(GetType()).Length;
        if (instant > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void playShootingSoundEffect()
    {
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, volume);
    }
    public void playDeadSmallEnemyEffect()
    {
        AudioSource.PlayClipAtPoint(deadsmallClip, Camera.main.transform.position, deadsmallvolume);
    }
    public void playDeadBigEnemyEffect() 
    {
        AudioSource.PlayClipAtPoint(deadBigClip, Camera.main.transform.position, deadBigvolume);
    }
    public void playDeadEnemyEffect() 
    {
        AudioSource.PlayClipAtPoint(deadClip, Camera.main.transform.position, deadvolume);
    }
    public void playPickUpEffect()
    {
        AudioSource.PlayClipAtPoint(pickupClip, Camera.main.transform.position, pickupClipVolume);
    }
    public void playFireBallEffect()
    {
        AudioSource.PlayClipAtPoint(fireBallClip, Camera.main.transform.position, fireBallVolume);
    }
    public void playEnemyHurtEffect()
    {
        AudioSource.PlayClipAtPoint(enemyHurtClip, Camera.main.transform.position, enemyHurtVolume);
    }
    public void playPlayerHurtEffect()
    {
        AudioSource.PlayClipAtPoint(playerHurtClip, Camera.main.transform.position, playerHurtVolume);
    }
    public void playShootingSwordEffect()
    {
        AudioSource.PlayClipAtPoint(shootingSwordClip, Camera.main.transform.position, shootingSwordVolume);
    }
    public void playShootingRockEffect()
    {
        AudioSource.PlayClipAtPoint(shootingRockClip, Camera.main.transform.position, shootingRockVolume);
    }

}
