using System;
using UnityEngine;

public class RegistraAccount : MonoBehaviour
{
    public void OnRegisterButtonClicked()
    {
        // Qui andrebbero letti i valori da InputField, questo è solo un esempio statico.
        string nome = "TestUser";
        string password = "TestPass";
        float saldoIniziale = 100.0f;

        // Usa UnityEngine.Object.FindFirstObjectByType per risolvere l'ambiguità
        AccountManager accountManager = UnityEngine.Object.FindFirstObjectByType<AccountManager>();
        if (accountManager != null)
        {
            accountManager.RegistraAccount(nome, password, saldoIniziale);
        }
        else
        {
            Debug.LogError("AccountManager non trovato!");
        }
    }
}
