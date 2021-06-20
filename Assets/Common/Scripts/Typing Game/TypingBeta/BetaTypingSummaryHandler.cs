using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static BetaTypingManager;

public class BetaTypingSummaryHandler : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] BetaTypingManager typingManager;
    [SerializeField] WordStatistics wordStatistics;
    [SerializeField] BetaTypingGameBossManager bossManager;
    [SerializeField] BetaTypingTimer timer;
    [SerializeField] BetaTypingPlayerManager playerManager;


    [Header("TMP")]
    [SerializeField] private TMP_Text damageTMP;
    [SerializeField] private TMP_Text accuracyTMP;
    [SerializeField] private TMP_Text currectTMP;
    [SerializeField] private TMP_Text incurrectTMP;
    [SerializeField] private TMP_Text currentBossHpTMP;
    [SerializeField] private TMP_Text maxBossHpTMP;
    [SerializeField] private Image bossHpFillBar;
    [SerializeField] private TMP_Text maxCombo;


    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }


    private void OnTypingGameStateChangedHandler(BetaTypingManager.TypingGameState state)
    {
        if(state == BetaTypingManager.TypingGameState.PostGame)
        {
            Innitialzing();
        }
    }

    private void Innitialzing()
    {
        damageTMP.text = bossManager.TotalDamaged.ToString();
        accuracyTMP.text = string.Format("{0:n2}", wordStatistics.GetAccuracy() * 100);
        currectTMP.text = wordStatistics.CorrectWord.ToString();
        incurrectTMP.text = wordStatistics.IncoreectWord.ToString();
        currentBossHpTMP.text = bossManager.CurrentHp.ToString();
        maxBossHpTMP.text = bossManager.MaxHp.ToString();
        bossHpFillBar.fillAmount = (float) bossManager.CurrentHp / bossManager.MaxHp;
        maxCombo.text = playerManager.MaxCombo.ToString();
    }

    public void Next()
    {
        typingManager.UpdateTypingGameState(TypingGameState.Summary);
        SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
