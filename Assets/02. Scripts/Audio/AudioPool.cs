using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool : MonoBehaviour
{
    [SerializeField] private GameObject audioObject;
    Queue<AudioObject> audioQueue = new Queue<AudioObject>();
    public static AudioPool instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("AudioPool instance is running");
        }
        instance = this;

        for(int i = 0; i < 15; i++)
        {
            AudioObject obj = Instantiate(audioObject, transform).GetComponent<AudioObject>();
            obj.gameObject.SetActive(false);
            audioQueue.Enqueue(obj);
        }
    }

    public void Play(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        AudioObject obj = null;
        if (audioQueue.Count > 0)
        {
            obj = audioQueue.Dequeue();
        }
        else
        {
            obj = Instantiate(audioObject, transform).GetComponent<AudioObject>();
        }
        obj.gameObject.SetActive(true);
        obj.Play(clip, volume, pitch);
        StartCoroutine(DQ(clip.length, obj));
    }
    IEnumerator DQ(float time, AudioObject obj)
    {
        yield return new WaitForSeconds(time + 0.1f);
        obj.gameObject.SetActive(false);
        audioQueue.Enqueue(obj);
    }
}