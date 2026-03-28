using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public static class Timer
{
    private static readonly Stopwatch stopwatch = new();
    private static List<long> steps = new();

    public static bool IsRunning
    {
        get => stopwatch.IsRunning;
    }

    public static double ElapsedSeconds
    {
        get => stopwatch.ElapsedMilliseconds * 0.001f;
    }

    public static int StepsCount
    {
        get => steps.Count;
    }

    public static double GetStepElapsedSeconds(int index)
    {
        return steps[index] * 0.001f;
    }

    /// <summary>
    /// Reset the timer and remove any steps.
    /// </summary>
    public static void Reset()
    {
        stopwatch.Reset();
        steps.Clear();
    }

    public static void Start()
    {
        stopwatch.Start();
    }

    public static void Stop()
    {
        stopwatch.Stop();
    }

    public static void Step()
    {
        steps.Add(stopwatch.ElapsedMilliseconds);
    }

    public static void Save()
    {
        List<string> lignes = new List<string>();

        foreach (long item in steps)
        {
            string texte = item.ToString();
            lignes.Add(texte);
        }

        string résultat = string.Join("\n", lignes.ToArray());

        //encodage
        byte[] byteTab = System.Text.Encoding.UTF8.GetBytes(résultat);
        string résultatEncodé = Convert.ToBase64String(byteTab);

        if (File.Exists("score.txt"))
        {
            string lastScore = File.ReadAllText("score.txt");

            byte[] bytesDecodés = Convert.FromBase64String(lastScore);
            string contenuDecodé = System.Text.Encoding.UTF8.GetString(bytesDecodés);

            string[] ligns = contenuDecodé.Split('\n');
            long valeur = long.Parse(ligns[ligns.Length -1]);

            if(valeur > steps[steps.Count - 1])
            {
                File.WriteAllText("score.txt", résultatEncodé);
            }
        }
        else
        {
            File.WriteAllText("score.txt", résultatEncodé);
        }
    }

    public static void Load()
    {
        if (File.Exists("score.txt"))
        {
            string toLoad = File.ReadAllText("score.txt");

            Byte[] bytesDecodés = Convert.FromBase64String(toLoad);
            string contenuDecodé = System.Text.Encoding.UTF8.GetString(bytesDecodés);

            string[] lignes = contenuDecodé.Split('\n');

            foreach (string item in lignes)
            {
                long valeur = long.Parse(item);
                steps.Add(valeur);
            }
        }
    }
}
