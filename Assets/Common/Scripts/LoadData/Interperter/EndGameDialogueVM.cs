using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDialogueVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_Id = "ID";
    private const string INST_SET_Bg = "Background";
    private const string INST_SET_Dia = "Dia";
    #endregion

    [SerializeField] private EndGameDialogues_Loading _endGameDialogues_Loading;

    public Dictionary<Grade, EndGameTemplate> Interpert()
    {
        if (!ReferenceEquals(_endGameDialogues_Loading, null))
        {
            Dictionary<Grade, EndGameTemplate> dialogueDic = new Dictionary<Grade, EndGameTemplate>();

            foreach (KeyValuePair<string, string> line in _endGameDialogues_Loading.textLists)
            {
                EndGameTemplate dialogue = null;
                string key = line.Key;
                string value = line.Value;

                dialogue = CreateTemplate(value);

                if (!ReferenceEquals(dialogue, null))
                {
                    dialogueDic.Add(dialogue.Grade, dialogue);
                }

            }
            if (!ReferenceEquals(dialogueDic, null))
            {
                return dialogueDic;
            }
        }

        return null;
    }

    private EndGameTemplate CreateTemplate(string line)
    {
        Grade grade = Grade.A;
        Sprite sprite = null;
        List<string> _dialogues = new List<string>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_Id:
                    grade = ConvertType.ConvertStringToGrade(entries[++i]);
                    break;
                case INST_SET_Bg:
                    sprite = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_Dia:
                    _dialogues.Add(entries[++i]);
                    break;

            }

        }

        return new EndGameTemplate(grade, sprite, _dialogues);
    }
}
