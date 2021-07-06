using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectDialogueVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_Id = "ID";
    private const string INST_SET_Npc = "NpcId";
    private const string INST_SET_Dia = "Dia";
    #endregion

    [SerializeField] private ProjectDialogue_Loading _projectDialogue_Loading;

    public Dictionary<ProjectPhase, ProjectDialogue_Template> Interpert()
    {
        if (!ReferenceEquals(_projectDialogue_Loading, null))
        {
            Dictionary<ProjectPhase, ProjectDialogue_Template> projectDialogueDic = new Dictionary<ProjectPhase, ProjectDialogue_Template>();

            foreach (KeyValuePair<string, string> line in _projectDialogue_Loading.textLists)
            {
                ProjectDialogue_Template dialogue = null;
                string key = line.Key;
                string value = line.Value;

                dialogue = CreateTemplate(value);

                if (!ReferenceEquals(dialogue, null))
                {
                    projectDialogueDic.Add(dialogue.ProjectPhase, dialogue);
                }

            }
            if (!ReferenceEquals(projectDialogueDic, null))
            {
                return projectDialogueDic;
            }
        }

        return null;
    }

    private ProjectDialogue_Template CreateTemplate(string line)
    {
        ProjectPhase _projectPhase = ProjectPhase.Decision;
        string _npcId = string.Empty;
        Dictionary<string, Dialogue> _dialogues = new Dictionary<string, Dialogue>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_Id:
                    _projectPhase = ConvertType.ConvertStringToProjectPhase(entries[++i]);
                    break;
                case INST_SET_Npc:
                    _npcId = entries[++i];
                    break;
                case INST_SET_Dia:
                    string id = entries[++i];
                    string text = entries[++i];
                    Feel feel = ConvertType.CheckFeel(entries[++i]);
                    _dialogues.Add(id, new Dialogue(text, feel));
                    break;

            }

        }

        return new ProjectDialogue_Template(_projectPhase, _npcId, _dialogues);
    }
}
