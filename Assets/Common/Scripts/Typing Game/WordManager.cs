using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : Manager<WordManager>
{
    public List<Word> wordlist;

    private bool hasActivedWord;
    private Word activeWord;

    [SerializeField] private WordSpawner wordSpawner;

    private void Start()
    {
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerater.GetRandomWord(), wordSpawner.SpawnWord());
        //Debug.Log(word.GetWord());

        wordlist.Add(word);
    }

    public void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if(activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
            }

        } else
        {
            //check for index 0 each Word in wordList
            foreach(Word eachWord in wordlist)
            {
                if(eachWord.GetNexLetter() == letter)
                {
                    activeWord = eachWord;
                    hasActivedWord = true;
                    eachWord.TypeLetterEachWord();
                    break;
                }
            }
        }

        if(hasActivedWord && activeWord.WordTypedEnd())
        {
            hasActivedWord = false;
            wordlist.Remove(activeWord);
        }
    }
}
