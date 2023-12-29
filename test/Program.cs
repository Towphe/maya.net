using maya.net;
using maya.net.Checkout;
using maya.net.Common;

//using maya.net.Wallet;
using maya.net.Webhooks;
using System.Linq;


// sandbox api keys
string _pk = "pk-eo4sL393CWU5KmveJUaW8V730TTei2zY8zE4dHJDxkF";
string _sk = "sk-KfmfLJXFdV5t1inYN8lIOwSrueC1G27SCAklBqYCdrU";

// sandbox pay keys
// string _pk = "pk-rpwb5YR6EfnKiMsldZqY4hgpvJjuy8hhxW2bVAAiz2N";
// string _sk = "sk-6s9dwnYGFJdZOYu1HCUAfUZctWEf9AjtHIG38kezX8W";

// IWebhookHandler webhookHandler = new WebhookHandler(_pk, _sk);

//Webhook res = await webhookHandler.CreateWebhook("AUTHORIZED", "https://www.facebook.com");
// IReadOnlyCollection<Webhook> hooks = await webhookHandler.GetWebhooks();
// foreach(Webhook w in hooks){
//     Console.WriteLine(w.Id);
// }
//Webhook hook = await webhookHandler.GetWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff"); // should output CHECKOUT_SUCCESS
//Webhook updated = await webhookHandler.UpdateWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff", "https://www.google.com");
//Webhook deleted = await webhookHandler.DeleteWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff");

ICheckoutHandler checkoutHandler = new CheckoutHandler(_pk);

Item item1 = new Item(){
    name = "Jabra Evolve 20",
    quantity = "1",
    totalAmount = new Total(){
        value = 420.69F
    }
};

List<Item> items = new List<Item>(){item1};

CheckoutBody req = new BasicCheckoutBody(){
    totalAmount = new TotalAmount(){
        value = 420.69F,
        currency = "PHP"
    },
    items = items,
    requestReferenceNumber = "1290409TJFKJ2339"   
};

CheckoutResponse res = await checkoutHandler.CreateCheckout(req);
Console.WriteLine(res.RedirectUrl);


// IWalletHandler _walletHandler = new WalletHandler(_pk, _sk);

// WalletResponse res = await _walletHandler.CreateSinglePayment(new WalletBody(){
//     totalAmount = new TotalAmount(){
//         value = 420.9F,
//         currency = "PHP"
//     },
//     redirectUrl = new RedirectUrl(){
//         success = "https://www.google.com",
//         failure = "https://x.com",
//         cancel = "https://instagram.com"
//     },
//     requestReferenceNumber = "93j2oidnodj3902",
//     metadata = new maya.net.Common.Metadata(){
//         subMerchantRequestReferenceNumber = "94ij02jd9209dj",
//         pf = new maya.net.Common.PaymentFacilitator(){
//             smi = "1",
//             smn = "Company",
//             mci = "Pasig",
//             mpc = "608",
//             mco = "PHL",
//             postalCode = "4320"
//         }
//     }
// });