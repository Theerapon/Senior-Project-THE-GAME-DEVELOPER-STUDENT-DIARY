using UnityEngine;
public class HardSkill_Template : MonoBehaviour
{

    [System.Serializable]
    public class HardSkillLevelRequired
    {
        public int exp_required;
        public int bonus_coding;
        public int bonus_design;
        public int bonus_testing;
        public int bonus_art;
        public int bonus_sound;

        public HardSkillLevelRequired(int requiredXP, int bonusCoding, int bonusDesign, int bonusTesting, int bonusArt, int bonusSound)
        {
            this.exp_required = requiredXP;
            this.bonus_coding = bonusCoding;
            this.bonus_design = bonusDesign;
            this.bonus_testing = bonusTesting;
            this.bonus_art = bonusArt;
            this.bonus_sound = bonusSound;
        }
    }

    #region Fields
    private HardSkillLevelRequired[] hardskillLevelRequired;
    private Sprite icon;
    private string hardskill_id = "";
    private string hardskill_name = "";
    private string hardskill_description = "";
    private int maxlevel;
    #endregion

    public HardSkill_Template(string id, string name, string description, int size, HardSkillLevelRequired[] hardskillLevelsList, Sprite icon)
    {
        hardskill_id = id;
        hardskill_name = name;
        hardskill_description = description;
        maxlevel = size;
        hardskillLevelRequired = hardskillLevelsList;
        this.icon = icon;
    }

    #region Reporter
    public HardSkillLevelRequired[] HardskillLevelRequired { get => hardskillLevelRequired; }
    public Sprite Icon { get => icon; }
    public string Hardskill_id { get => hardskill_id; }
    public string Hardskill_name { get => hardskill_name; }
    public string Hardskill_description { get => hardskill_description; }
    public int Maxlevel { get => maxlevel; }
    #endregion

}
