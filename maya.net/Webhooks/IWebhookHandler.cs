namespace maya.net.Webhooks;

using System.Collections.Generic;

public interface IWebhookHandler{
    /// <summary>
    /// Method <c>CreateWebhook</c> creates a webhook of type 'name' and assigns a 'callback'.
    /// </summary>
    public Task<Webhook?> CreateWebhook(string name, string callback);
    /// <summary>
    /// Gets all webhooks under an account.
    /// </summary>
    public Task<IReadOnlyCollection<Webhook>?> GetWebhooks();
    /// <summary>
    /// Gets a specific webhook by its webhookId.
    /// </summary>
    public Task<Webhook?> GetWebhook(string webhookId);
    /// <summary>
    /// Updates a webhook's callbackUrl. 
    /// </summary>
    public Task<Webhook?> UpdateWebhook(string webhookId, string callbackUrl);
    /// <summary>
    /// Deletes a webhook.
    /// </summary>
    public Task<Webhook?> DeleteWebhook(string webhookId);
}