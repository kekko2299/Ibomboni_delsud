using System;
using UnityEngine;

public class LoginAccount : MonoBehaviour
{
    public void OnLoginButtonClicked()
    {
        // Qui andrebbero letti i valori da InputField, questo è solo un esempio statico.
        string nome = "TestUser";
        string password = "TestPass";

        // Usa UnityEngine.Object.FindFirstObjectByType per risolvere l'ambiguità
        AccountManager accountManager = UnityEngine.Object.FindFirstObjectByType<AccountManager>();
        if (accountManager != null)
        {
            Account account = accountManager.LoginAccount(nome, password);
            if (account != null)
            {
                Debug.Log($"Login effettuato! Benvenuto {account.nome}");
                // Prosegui con la logica dopo il login
            }
            else
            {
                Debug.Log("Nome utente o password errata!");
            }
        }
        else
        {
            Debug.LogError("AccountManager non trovato!");
        }
    }
}
