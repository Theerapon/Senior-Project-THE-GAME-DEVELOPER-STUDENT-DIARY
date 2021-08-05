using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static BetaTypingManager;

public class BetaTypingSummaryHandler : MonoBehaviour
{
    private readonly float[] bonusEfficiency = { -0.5f, -0.1f, 0.1f, 0.15f, 0.2f, 0.35f, 0.5f, 0.7f, 1f, 1.5f, 2f, 3f };
    private readonly int[] scoreStandard = { 0, 0, 0, 0, 25000, 80000, 150000, 250000, 340000, 500000, 850000, 1250000, };
    private int indexOfEfficiency;

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
    [SerializeField] private TMP_Text efficiencyBonus;


    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }


    private void OnTypingGameStateChangedHandler(BetaTypingManager.TypingGameState state)
    {
        if(state == BetaTypingManager.TypingGameState.PostGame)
        {
            indexOfEfficiency = CalculateIndexOfEfficiency();
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
        efficiencyBonus.text = string.Format("{0:p0}", bonusEfficiency[indexOfEfficiency]);
        if (ProjectController.Instance != null)
            ProjectController.Instance.MiniGameBonusEfficiency = bonusEfficiency[indexOfEfficiency];
    }
    private int CalculateIndexOfEfficiency()
    {
        int index = 0;
        int damaged = bossManager.TotalDamaged;
        int correct = wordStatistics.CorrectWord;
        int incorrect = wordStatistics.IncoreectWord;
        int maxCombo = playerManager.MaxCombo;
        int standardScore = (((correct + incorrect)) + playerManager.CountCombo[playerManager.MaxComboPhase - 1]);
        int recieveScore = ((correct + maxCombo) - (incorrect * 5));
        float avgScore = (float)recieveScore / standardScore;
        if (avgScore <= 0.5f)
        {
            index = 0;
        }
        else if (avgScore <= 0.6f)
        {
            index = 1;
        }
        else if (avgScore <= 0.7f)
        {
            index = 2;
        }
        else if (avgScore <= 0.8f)
        {
            index = 3;
        }
        else
        {
            index = 3;
            for (int i = 4; i < scoreStandard.Length; i++)
            {
                if (damaged >= scoreStandard[i])
                {
                    index = i;
                }
            }
        }

        return index;
    }
    public void Next()
    {
        typingManager.UpdateTypingGameState(TypingGameState.Summary);
        if (SwitchScene.Instance != null)
            SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
