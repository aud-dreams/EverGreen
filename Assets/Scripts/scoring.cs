using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class scoring : MonoBehaviour
{
    private static List<string> path = new List<string>();
    public static GameObject Scoring;
    public static Dictionary<string, int> problem;
    public static List<string> answer_path;
    public static int answer_length;
    public static float score;

    void Start()
    {
        scoring.Scoring = this.gameObject;
        UpdateProblem();

        // post curlevel

        // 
    }

    public static void UpdateProblem()
    {
        if (question_bank.question_number == 1)
        {
            problem = question_bank.problem1;
            answer_path = question_bank.path1;
            answer_length = question_bank.length1;
        }
        else if (question_bank.question_number == 2)
        {
            problem = question_bank.problem2;
            answer_path = question_bank.path2;
            answer_length = question_bank.length2;
        }
        else if (question_bank.question_number == 3)
        {
            problem = question_bank.problem3;
            answer_path = question_bank.path3;
            answer_length = question_bank.length3;
        }
    }

    public static void CheckScore(List<string> selectedNodes)
    {
        // calculate user answer
        UpdateProblem();
        path.Clear();
        string prev_node = "";
        int user_length = 0;
        foreach (string node in selectedNodes)
        {

            if (prev_node != "")
            {
                string edge = prev_node + node;
                string reversedEdge = node + prev_node;

                if (problem.ContainsKey(edge))
                {
                    user_length += problem[edge];
                }
                else if (problem.ContainsKey(reversedEdge))
                {
                    // add the length (edge is reversed)
                    user_length += problem[reversedEdge];
                }
            }
            prev_node = node;
        }

        // check against real answer & create score

        // 1 = correct, less nodes correct = smaller ratio
        int correctNodes = selectedNodes.Count(node => answer_path.Contains(node));
        float correctNodeScore = (float)correctNodes / answer_path.Count;

        // 1 = correct, farther away their score = smaller ratio
        float efficiencyScore = (float)answer_length / user_length;

        // 1 = correct, too many nodes chosen = smaller ratio
        float redundantSteps = (float)answer_path.Count / selectedNodes.Count;

        score = (correctNodeScore / 3f) + (efficiencyScore / 3f) + (redundantSteps / 3f);

        // post score


        question_bank.question_number++;
        Scoring.SetActive(false);
    }
}
