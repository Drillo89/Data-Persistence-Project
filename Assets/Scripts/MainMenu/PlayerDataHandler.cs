using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataHandler : MonoBehaviour
{
    //singleton pattern
    public static PlayerDataHandler Instance;
    private string typedPlayerName;
    private int hsValue;
    private string hsPlayerName;
    

   private void Awake()
   {
       // Se esiste già un'istanza del MainManager, distruggi l'oggetto duplicato
       if (Instance != null && Instance != this) 
      
       { 
           Destroy(this.gameObject); return; 
       } 

       Instance = this; 
       DontDestroyOnLoad(this.gameObject); // Mantieni l'oggetto quando si cambia scena
       LoadHighScore();
   }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        
    }

    public void SetPlayerName(string playerName)
    {
        typedPlayerName = playerName;
    }

    public string GetPlayerName()
    {
        return typedPlayerName;
    }

    
    [System.Serializable]
     class SaveData
    {
        public int highScore;
        public string playerName;
    }

    
    public void SaveHighScore(string pName, int highS)
    {
        SaveData data = new SaveData();
        data.playerName = pName;
        data.highScore = highS;
        

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }
    
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
            hsValue = data.highScore;
        hsPlayerName = data.playerName;
           
        }
    }

   public int GetHighScore()
    {
        return hsValue;
    }

   public string GetHSPlayerName()
    {
        return hsPlayerName;
    }
    
}
