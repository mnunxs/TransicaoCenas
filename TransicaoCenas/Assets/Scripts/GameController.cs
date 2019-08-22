using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instancia;

    [SerializeField] float incrementoMeta;
    [SerializeField] Text textoscore;
    [SerializeField] Text textoRecord;
    float meta;
    int score, record;

    private void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        record = 0;
        CarregaRecord();
        atualizaRecordHUD();
        atualizaScoreHUD();
        meta = Mathf.Log(meta + incrementoMeta, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            score += 1;
            atualizaScoreHUD();
        }

        if (score >= meta)
        {
            meta += Mathf.Log(meta + incrementoMeta, 2.0f) * 10;
            SceneManager.LoadScene("Level02");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SairDoJogo();
        }

        
    }

    void atualizaScoreHUD()
    {
        textoscore.text = "Score: " + score;
    }

   
    void atualizaRecordHUD()
    {
        textoRecord.text = "Record: " + record;
    }

    void CarregaRecord()
    {
        if (PlayerPrefs.HasKey("record"))
        {
            record = PlayerPrefs.GetInt("record");
        }
        atualizaRecordHUD();

    }

    void SairDoJogo()
    {
        if (score > record)
        {
            PlayerPrefs.SetInt("record", score);
        }


#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
