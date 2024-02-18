using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class question_bank : MonoBehaviour
{
    public static int question_number = 1;
    public static Dictionary<string, int> problem1 = new Dictionary<string, int>
    {
        { "AB", 2 },
        { "BC", 5 },
        { "AD", 4 },
        { "DE", 2 },
        { "EF", 3 },
        { "CF", 3 },
        { "BE", 1 },
    };

    public static List<string> path1 = new List<string> { "A", "B", "E", "F" };

    public static int length1 = 6;

    public static Dictionary<string, int> problem2 = new Dictionary<string, int>
    {
        { "AB", 3 },
        { "BC", 4 },
        { "AD", 4 },
        { "DE", 1 },
        { "EF", 2 },
        { "CF", 6 },
        { "BE", 3 },
    };
    public static List<string> path2 = new List<string> { "A", "D", "E", "F" };

    public static int length2 = 7;

    public static Dictionary<string, int> problem3 = new Dictionary<string, int>
    {
        { "AB", 4 },
        { "BC", 3 },
        { "AD", 2 },
        { "DE", 3 },
        { "EF", 5 },
        { "CF", 1 },
        { "BE", 2 },
        { "AC", 5 },
    };

    public static List<string> path3 = new List<string> { "A", "B", "C", "F" };

    public static int length3 = 8;
}
