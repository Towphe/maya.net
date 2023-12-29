namespace maya.net.Wallet;

public interface IWalletHandler{
    ///<summary>
    /// Creates a Maya wallet transaction.
    ///</summary>
    public Task<WalletResponse?> CreateSinglePayment(WalletBody wallet);
}