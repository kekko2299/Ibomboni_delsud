using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    // Percorso del file degli account
    private string filePath;
    // Lista degli account caricati
    private List<Account> accounts;

    // Riferimento al pannello dell'account (da assegnare nell’Inspector)
    public GameObject accountPanel;

    private void Start()
    {
        // Imposta il file degli account nella cartella persistente di Unity
        filePath = Path.Combine(Application.persistentDataPath, "account.txt");
        LoadAccounts();
    }

    // Carica gli account dal file
    void LoadAccounts()
    {
        accounts = new List<Account>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                // Formattazione attesa: nome password saldo
                string[] parts = line.Split(' ');
                if (parts.Length >= 3)
                {
                    Account acc = new Account();
                    acc.nome = parts[0];
                    acc.password = parts[1];
                    if (float.TryParse(parts[2], out float saldo))
                        acc.saldo = saldo;
                    accounts.Add(acc);
                }
            }
        }
        else
        {
            Debug.Log("Nessun file account trovato. Verrà creato uno nuovo al salvataggio.");
        }
    }

    // Salva gli account sul file
    void SaveAccounts()
    {
        List<string> lines = new List<string>();
        foreach(Account acc in accounts)
        {
            lines.Add($"{acc.nome} {acc.password} {acc.saldo:F2}");
        }
        File.WriteAllLines(filePath, lines.ToArray());
    }

    // Verifica se esiste già un account con il nome specificato
    public bool AccountEsistente(string nome)
    {
        foreach(Account acc in accounts)
        {
            if(acc.nome == nome)
                return true;
        }
        return false;
    }

    // Registra un nuovo account
    public void RegistraAccount(string nome, string password, float saldoIniziale)
    {
        if (AccountEsistente(nome))
        {
            Debug.Log("L'account esiste già!");
            return;
        }
        Account nuovo = new Account();
        nuovo.nome = nome;
        nuovo.password = password;
        nuovo.saldo = saldoIniziale;
        accounts.Add(nuovo);
        SaveAccounts();
        Debug.Log("Registrazione completata con successo!");
    }

    // Effettua il login: restituisce l'account se le credenziali sono corrette, altrimenti null
    public Account LoginAccount(string nome, string password)
    {
        foreach(Account acc in accounts)
        {
            if(acc.nome == nome && acc.password == password)
            {
                Debug.Log($"Login effettuato! Benvenuto {acc.nome}");
                return acc;
            }
        }
        Debug.Log("Nome utente o password errata!");
        return null;
    }

    // Aggiorna i dati dell'account e salva il file
    public void AggiornaAccount(Account accountAggiornato)
    {
        for (int i = 0; i < accounts.Count; i++)
        {
            if(accounts[i].nome == accountAggiornato.nome)
            {
                accounts[i] = accountAggiornato;
                break;
            }
        }
        SaveAccounts();
    }

    // Mostra il pannello dell'account
    public void ShowAccountPanel()
    {
        if (accountPanel != null)
        {
            accountPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("accountPanel non è assegnato in AccountManager!");
        }
    }

    // Nasconde il pannello dell'account
    public void HideAccountPanel()
    {
        if(accountPanel != null)
        {
            accountPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("accountPanel non è assegnato in AccountManager!");
        }
    }
}
