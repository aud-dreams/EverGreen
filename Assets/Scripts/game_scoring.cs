using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;
using System.Text;

public class game_scoring : MonoBehaviour
{
    private static float startTime;
    public static float elapsedTime => Time.time - startTime;
    public static int finish_bool = 0;

    public static List<Tuple<float, bool>> rounds = new List<Tuple<float, bool>>();

    private static float finalScore = 0;

    private string jsonData;

    void Start()
    {
        startTime = Time.time;
    }

    IEnumerator Upload()
    {
        byte[] formData = Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/scores", ""))
        {
            www.uploadHandler = new UploadHandlerRaw(formData);
            www.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
            www.SetRequestHeader("Authorization", "Bearer " + user.token);
            www.timeout = 15;
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                Debug.Log(jsonData);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }

    void Update()
    {
        if (finish_bool == 1)
        {
            // calculate final scores
            foreach (var round in rounds)
            {
                finalScore += round.Item1;
            }
            finalScore /= 3;

            finish_bool = 0;

            // parse rounds
            List<Dictionary<string, object>> new_rounds = new List<Dictionary<string, object>>();
            foreach (var round in rounds)
            {
                Dictionary<string, object> roundDict = new Dictionary<string, object> {
                    { "score", round.Item1 },
                    { "revealed_answer", round.Item2 }
                };

                new_rounds.Add(roundDict);
            }

            var obj = new
            {
                game_category = "Dijkstra's",
                game_difficulty = "beginner",
                rounds = new_rounds,
                average_score = finalScore,
                time_taken = finish_game.timespent
            };

            // Serializing the object to a JSON string
            jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);

            StartCoroutine(Upload());

            // quit
            Application.Quit();
        }
    }
}
