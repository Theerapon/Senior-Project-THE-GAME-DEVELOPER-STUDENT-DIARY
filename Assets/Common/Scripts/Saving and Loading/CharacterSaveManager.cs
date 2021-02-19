using UnityEngine;

public class CharacterSaveManager : MonoBehaviour, ISaveable
{
    private const string KEY = "PlayerData";
    Rigidbody rgbody;

    
    
    void Start()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSaveInitiated.AddListener(HandleOnSave);
        }

        rgbody = GetComponent<Rigidbody>();
        OnLoaded();
    }

    private void HandleOnSave()
    {
        OnSaved();
    }

    public void OnLoaded()
    {
        if (SaveLoad.SaveExists(KEY))
        {
            PlayerData playerData = SaveLoad.Load<PlayerData>(KEY);
            Vector3 position;
            position.x = playerData.position[0];
            position.y = playerData.position[1];
            position.z = playerData.position[2];
            rgbody.transform.position = position;
        }
    }

    public void OnSaved()
    {
        SaveLoad.Save(new PlayerData(this), KEY);
    }
}

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public PlayerData(CharacterSaveManager player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
