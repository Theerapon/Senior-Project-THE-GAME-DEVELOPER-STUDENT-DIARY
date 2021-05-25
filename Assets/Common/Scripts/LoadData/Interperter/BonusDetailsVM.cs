using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDetailsVM : MonoBehaviour
{
    private const string INST_SET_bonusID = "bonusID";
    private const string INST_SET_bonusName = "bonusName";
    private const string INST_SET_icon = "icon";

    private BonusDetail_Loading bonusDetailLoading;


    private void Start()
    {
        bonusDetailLoading = BonusDetail_Loading.instance;
    }

    public Dictionary<string, Bonus> Interpert()
    {
        if (!ReferenceEquals(bonusDetailLoading, null))
        {
            Dictionary<string, Bonus> bonus_dic = new Dictionary<string, Bonus>();

            foreach (KeyValuePair<string, string> line in bonusDetailLoading.textLists)
            {
                Bonus bonus = null;
                string key = line.Key;
                string value = line.Value;

                bonus = CreateTemplate(value);

                if (!ReferenceEquals(bonus, null))
                {
                    bonus_dic.Add(bonus.BonusID, bonus);
                }

            }
            if (!ReferenceEquals(bonus_dic, null))
            {
                return bonus_dic;
            }
        }

        return null;
    }

    public Bonus CreateTemplate(string line)
    {
        string id = "";
        string name = "";
        Sprite icon = null;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_bonusID:
                    id = entries[++i];
                    break;
                case INST_SET_bonusName:
                    name = entries[++i];
                    break;
                case INST_SET_icon:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                
            }

        }
        return new Bonus(id, name, icon);
    }
}
