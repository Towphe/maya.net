# About
Maya.net is a simple C#/.NET API wrapper for Maya's (or Paymaya) collection of APIs. This allows for easier integration of Maya's payment services to your .NET applications. 

## Basic Usage
Every major endpoint collection of Maya (e.g. Checkout, Wallet, etc.) have their own handlers. For instance, if you plan on using Checkout:


## Features

- Easier Integration to Maya's APIs
- support for both Production and Sandbox APIs
- current supports:
    1. [Maya Checkout]("https://developers.maya.ph/reference/createv1checkout")
    2. [Maya Wallet]("https://developers.maya.ph/reference/createv2singlepayment")
    3. [Webhook Management]("https://developers.maya.ph/reference/createv1webhook-1")
    4. [Maya QR]("https://developers.maya.ph/reference/createdynamicqr")
    5. [Payment Transaction Management]("https://developers.maya.ph/reference/capturev1payment")



## Usage/Examples

```c#
using maya.net.Checkout;

string _pKey = "<your unique public key goes here>";

ICheckoutHandler checkoutHandler = new CheckoutHandler(_pKey, isSandbox = true);

Item item1 = new Item(){
    name = "Item 1",
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
    requestReferenceNumber = "1290409TJFKJ2339" // must be unique  
};

CheckoutResponse res = await checkoutHandler.CreateCheckout(req);
Console.WriteLine(res.RedirectUrl); // prints Maya payment redirect URL
```


## Dependency Injection

Maya.net fully supports dependency injection. Simply add the interface of a handler in service as follows:

```c#
...

// parameters: pKey, isSandbox (false if using Production API)
builder.Services.AddScoped<ICheckoutHandler>(inst => ActivatorUtilities.CreateInstance<CheckoutHandler>(inst, builder.Configuration["maya-basic-pk"], false));

...
```


## License

This project is fully open source and uses the [MIT](https://choosealicense.com/licenses/mit/) License.


## Roadmap

- ~~Maya Checkout~~
- ~~Maya Wallet~~
- ~~Webhook Management~~
- ~~Payment Transactions Management~~
- ~~Maya QR~~
- Maya Wallet Link Support
- Utility Endpoints
- Maya P3
- Disbursement API
- Money Movement
- Remittance
- General Documentation

## Documentation

A comprehensive documentation would be provided at a later date. For the meantime, refer to the project's Github repository [here]("https://github.com/Towphe/maya.net").


## Feedback

If you have any feedback, please reach out to me at jccastillo1105@gmail.com.

