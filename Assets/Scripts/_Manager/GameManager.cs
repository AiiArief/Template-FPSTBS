﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    PhaseManager m_phaseManager;
    PlayerManager m_playerManager;
    EnemyManager m_enemyManager;
    LevelManager m_levelManager;

    private void Awake()
    {
        Instance = this;

        m_phaseManager = GetComponentInChildren<PhaseManager>();
        m_playerManager = GetComponentInChildren<PlayerManager>();
        m_enemyManager = GetComponentInChildren<EnemyManager>();
        m_levelManager = GetComponentInChildren<LevelManager>();
    }

    private void OnEnable()
    {
        // set cutscene, config all manager, idk
        m_playerManager.SetupPlayersOnLevelStart(1); // temp
        m_phaseManager.SetPhase(PhaseEnum.WaitInput);

        Cursor.lockState = CursorLockMode.Locked; // kalo pause munculin cursor;
    }

    private void Update()
    {
        // kalo win atau apapun ya jangan update atuh
        if (m_phaseManager.currentPhase != PhaseEnum.None)
            m_phaseManager.UpdateCurrentPhase();
    }
}