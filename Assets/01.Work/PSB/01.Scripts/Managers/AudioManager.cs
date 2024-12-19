using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class UIVolumeSetting
{
    public float musicVolume;
    public float sfxVolume;
}


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private string filePath;
    [SerializeField] private string nextScene;

    private BGMScript BGMScript;

    private void Start()
    {
        Time.timeScale = 1f;

        BGMScript = FindAnyObjectByType<BGMScript>();

        if (BGMScript != null)
        {
            Destroy(BGMScript.gameObject);
            //BGMScript.StopBGM();
        }

        #region Music Sound Load

        filePath = Path.Combine(Application.persistentDataPath, "volumeSettings.json");
        LoadVolume();

        musicSlider.onValueChanged.AddListener(value =>
        {
            audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
            SaveVolume();
        });

        sfxSlider.onValueChanged.AddListener(value =>
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
            SaveVolume();
        });
        #endregion

    }

    public void StartBtnClick()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void SaveVolume()
    {
        UIVolumeSetting settings = new UIVolumeSetting
        {
            musicVolume = musicSlider.value,
            sfxVolume = sfxSlider.value
        };

        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(filePath, json);
    }

    public void LoadVolume()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            UIVolumeSetting settings = JsonUtility.FromJson<UIVolumeSetting>(json);
            musicSlider.value = settings.musicVolume;
            sfxSlider.value = settings.sfxVolume;

            audioMixer.SetFloat("Music", Mathf.Log10(settings.musicVolume) * 20);
            audioMixer.SetFloat("SFX", Mathf.Log10(settings.sfxVolume) * 20);
        }
        else
        {
            musicSlider.value = 1.0f;
            sfxSlider.value = 1.0f;
            SaveVolume();
        }
    }
}
