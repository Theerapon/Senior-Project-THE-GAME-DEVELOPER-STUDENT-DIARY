using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingBullet : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private BetaTypingManager wordManager;
    private float screenHalfWidth;
    private float screenHalfHeight;

    #region Instace tag
    private const string INST_BOSS = "BetaBoss";
    private const string INST_Monster = "BetaMonster";
    #endregion

    public enum BulletState
    {
        Create,
        Shoting,
        Explosion,
    }
    private BulletState bulletState = BulletState.Create;

    private Vector3 direction;
    [SerializeField] private int speed;

    private int damage;
    private string baseWordID;

    private bool shootBoss;
    private bool outOffScreen = false;

    private void Start()
    {
        wordManager = BetaTypingManager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        screenHalfHeight = wordManager.GetCanvasHeight() / 2;
    }
    public void Shooting(Vector3 position, int damage, string baseWordId)
    {
        this.damage = damage;
        direction = (transform.position - position).normalized;
        UpdateState(BulletState.Shoting);
        this.baseWordID = baseWordId;
        shootBoss = false;
    }
    public void Shooting(Vector3 position, int damage)
    {
        this.damage = damage;
        direction = (transform.position - position).normalized;
        UpdateState(BulletState.Shoting);
        shootBoss = true;
    }

    private void Update()
    {
        switch (bulletState)
        {
            case BulletState.Create:
                break;
            case BulletState.Shoting:
                transform.position -= direction * speed * Time.deltaTime;
                if (transform.position.x < -screenHalfWidth || transform.position.x > screenHalfWidth
                || transform.position.y < -screenHalfHeight || transform.position.y > screenHalfHeight)
                {
                    outOffScreen = true;
                    OnDestroy();
                }
                break;
            case BulletState.Explosion:
                OnDestroy();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case INST_BOSS:
                if (shootBoss)
                {
                    collision.gameObject.GetComponent<BetaTypingGameBossManager>().TakeDamaged(damage);
                    UpdateState(BulletState.Explosion);
                }
                break;
            case INST_Monster:
                if (!shootBoss)
                {
                    BetaWordTypingMonsterBox betaWordTypingMonster = collision.gameObject.GetComponentInChildren<BetaWordTypingMonsterBox>();
                    if (betaWordTypingMonster.Id.Equals(baseWordID))
                    {
                        collision.gameObject.GetComponentInChildren<BetaWordTypingMonsterBox>().TakeDamage();
                        UpdateState(BulletState.Explosion);
                    }
                }
                break;
        }
    }


    private void UpdateState(BulletState state)
    {
        bulletState = state;
    }

    private void OnDestroy()
    {
        Destroy(obj);
    }
}
