using maya.net.Webhooks;

string _pk = "pk-Z0OSzLvIcOI2UIvDhdTGVVfRSSeiGStnceqwUE7n0Ah";
string _sk = "sk-X8qolYjy62kIzEbr0QRK1h4b4KDVHaNcwMYk39jInSl";

IWebhookHandler webhookHandler = new WebhookHandler(_pk, _sk);

//Webhook res = await webhookHandler.CreateWebhook("AUTHORIZED", "https://www.facebook.com");
//IReadOnlyCollection<Webhook> hooks = await webhookHandler.GetWebhooks();
//Webhook hook = await webhookHandler.GetWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff"); // should output CHECKOUT_SUCCESS
//Webhook updated = await webhookHandler.UpdateWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff", "https://www.google.com");
//Webhook deleted = await webhookHandler.DeleteWebhook("bf40baf7-7f3c-4541-b67f-8acd0ec966ff");
