﻿// Jann

/// This script creates notes based on this: https://pages.mtu.edu/~suits/NoteFreqCalcs.html

// Jann 16/10/20 - Implemented note calculation
// Jann 21/10/20 - Adjustments
// Jann 25/10/20 - Refactored parts to PlayTrack_Jann.cs
// Jann 28/10/20 - QA improvements
// Jann 11/11/20 - Added GetNotes(frequency)
// Jann 22/11/20 - Added more notes (C2 - C3)

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotesCreator_Jann
{
    private const int BF = 440;
    private const int F = -33;
    private const int T = 15;
    private const float FR = 1.059463094359f;

    private int p;
    private int a;
    private float inc;
    private float ph;
    private int cn;

    private Dictionary<Note, int> nfs = new Dictionary<Note, int>();

    public enum Note
    {
        None = 0, 
        C2, Db2, D2, Eb2, E2, F2, Gb2, G2, Ab2, A2, Bb2, B2, 
        C3, Db3, D3, Eb3, E3, F3, Gb3, G3, Ab3, A3, Bb3, B3, 
        C4, Db4, D4, Eb4, E4, F4, Gb4, G4, Ab4, A4, Bb4, B4, 
        C5, Db5, D5, Eb5, E5, F5, Gb5, G5, Ab5, A5, Bb5, B5, 
        C6
    };

    public NotesCreator_Jann()
    {
        GN();
    }

    public int GetFrequency(Note n)
    {
        return nfs[n];
    }

    public Note GetNote(int f)
    {
        return nfs.FirstOrDefault(pair => Math.Abs(pair.Value - f) < 0.1f).Key;
    }
    
    private void GN()
    {
        nfs.Add(Note.None, 0);

        int i = 0;
        for (int fr = F; fr < T + 1; fr++)
        {
            i++;
            nfs.Add((Note) i, (int) (BF * Mathf.Pow(FR, fr)));
        }
    }
}