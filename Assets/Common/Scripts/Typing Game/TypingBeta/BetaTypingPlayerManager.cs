using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingPlayerManager : Manager<BetaTypingPlayerManager>
{
    public Events.EventOnBetaTypingPlayerUpdate OnBetaTypingPlayerUpdate;
    public Events.EventOnBetaTypingPlayerStateChange OnBetaTypingPlayerStateChange;

    public enum BetaPlayerState
    {
        Alive,
        Dead,
        Timeout
    }
    private BetaPlayerState playerState;

    public enum BetaComboPhase : int
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Phase5
    }
    private BetaComboPhase comboPhase;

    private CharacterStatusController characterStatusController;

    #region Instace
    private const int INST_LIFE = 3;
    private const int INST_UltimateSkill = 5;
    private const int INST_DamageMultiplier = 25;
    #endregion

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Beta Typing")]
    [SerializeField] private BetaTypingManager betaTypingManager;
    [SerializeField] private RectTransform rectCanvas;
    private Vector3 positionShooting;

    private int countMonsterKilledToUltimateSkill;
    private int life;
    private int damage = 0;
    private int currentCombo;
    private int maxCombo;
    private readonly int maxComboPhase = 5;
    private int[] countCombo = { 0, 14, 25, 50, 75 };
    private float[] comboDamageMultiplier = { 1f, 1.5f, 2.5f, 4f, 8f };

    public BetaPlayerState PlayerState { get => playerState; }
    public BetaComboPhase GetComboPhase { get => comboPhase; }
    public int Combo { get => currentCombo; }
    public int Life { get => life; }
    public int CountMonsterKilledToUltimateSkill { get => countMonsterKilledToUltimateSkill; }
    public int[] CountCombo { get => countCombo; }

    public int MaxComboPhase => maxComboPhase;

    public int MaxCombo { get => maxCombo; }

    protected override void Awake()
    {
        base.Awake();
        characterStatusController = CharacterStatusController.Instance;
        Initailzing();
    }

    private void Initailzing()
    {
        life = 3;
        countMonsterKilledToUltimateSkill = 0;
        currentCombo = 0;
        maxCombo = currentCombo;
        //damage = characterStatusController.CurrentTestingStatus * INST_DamageMultiplier;
        damage = 40 * INST_DamageMultiplier;
        UpdatePlayerState(BetaPlayerState.Alive);
        UpdateComboPhase(BetaComboPhase.Phase1);
    }

    private void Start()
    {
        positionShooting = betaTypingManager.PlayerPosition.transform.position;
    }

    public void Shooting(Vector3 positionTarget)
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShooting, Quaternion.identity, rectCanvas);
        int damage = this.damage * (int)(comboDamageMultiplier[(int)comboPhase]);
        bullet.GetComponent<BetaTypingBullet>().Shooting(positionTarget, damage);
    }

    public void Shooting(Vector3 positionTarget, string id)
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShooting, Quaternion.identity, rectCanvas);
        int damage = this.damage * (int)(comboDamageMultiplier[(int)comboPhase]);
        bullet.GetComponent<BetaTypingBullet>().Shooting(positionTarget, damage, id);
    }

    public void KillMonster()
    {
        if(countMonsterKilledToUltimateSkill + 1 <= INST_UltimateSkill)
        {
            countMonsterKilledToUltimateSkill++;
        }
        IncreaseCombo();
    }

    public void AttackBoss()
    {
        IncreaseCombo();
    }

    private void IncreaseCombo()
    {
        currentCombo++;
        if(currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

        if((int)comboPhase < maxComboPhase - 1)
        {
            if (currentCombo >= countCombo[(int)comboPhase + 1])
            {
                UpdateComboPhase(comboPhase + 1);
            }
        }
        OnBetaTypingPlayerUpdate?.Invoke();
    }

    public void ReduceCombo()
    {
        currentCombo = 0;
        UpdateComboPhase(BetaComboPhase.Phase1);
    }

    public bool CanUseUltimateSkill()
    {
        return countMonsterKilledToUltimateSkill >= INST_UltimateSkill;
    }

    public void UseUlitmateSkill()
    {
        betaTypingManager.UseUltimateSKill(2);
        countMonsterKilledToUltimateSkill = 0;
        OnBetaTypingPlayerUpdate?.Invoke();
    }

    public void TakeDamage()
    {
        if(life - 1 <= 0)
        {
            life = 0;
            UpdatePlayerState(BetaPlayerState.Dead);
        }
        else
        {
            life--;
        }
        ReduceCombo();
    }

    public void TimeOut()
    {
        UpdatePlayerState(BetaPlayerState.Timeout);
    }


    private void UpdatePlayerState(BetaPlayerState state)
    {
        playerState = state;
        OnBetaTypingPlayerUpdate?.Invoke();
        OnBetaTypingPlayerStateChange?.Invoke(playerState);

    }

    private void UpdateComboPhase(BetaComboPhase phase)
    {
        comboPhase = phase;
        OnBetaTypingPlayerUpdate?.Invoke();  
    }

    public bool HasAlive()
    {
        return BetaPlayerState.Alive == playerState;
    }
}
