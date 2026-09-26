using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();

        _walletView.Initialize(_wallet);
    }
}
