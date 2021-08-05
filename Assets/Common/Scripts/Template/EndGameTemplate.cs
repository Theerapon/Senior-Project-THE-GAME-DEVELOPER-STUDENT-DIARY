using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Grade { A, B, C, D, F }
public class EndGameTemplate : MonoBehaviour
{
    private Grade _grade;
    private Sprite _image;
    private List<string> _dialogues;

    public EndGameTemplate(Grade grade, Sprite image, List<string> dialogues)
    {
        _grade = grade;
        _image = image;
        _dialogues = dialogues;
    }

    public Grade Grade { get => _grade; }
    public Sprite Image { get => _image; }
    public List<string> Dialogues { get => _dialogues; }
}
