using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AliasGPT;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI;
using Unity.VisualScripting;
using UnityEngine;

public class StartGameCommand
{
    private const int maxIterations = 3;
    private OpenAIApi openai 
        = new OpenAIApi("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");

    private readonly GameContext _gameContext;
    private readonly GameplayController _gameplayController;
    private readonly WordsProvider _wordsProvider;

    public StartGameCommand(GameContext gameContext, GameplayController gameplayController, WordsProvider wordsProvider)
    {
        _gameContext = gameContext;
        _gameplayController = gameplayController;
        _wordsProvider = wordsProvider;
    }

    public async UniTask Execute()
    {
        //get gpt words
        var sendGptRequest = await SendGPTRequest(_gameContext.CommonThemeName.Value);
        //parse words
        var result = TryParseMessage(sendGptRequest.Content);
        
        if(result == null)
        {
            Debug.LogError("GPT3 returned null");
            return;
        }
        
        //set words to provider
        _wordsProvider.Initialize(result);
        
        _gameplayController.StartGameplayLoop();
        
        //TODO: ALSO SCREEN TO HIDE LOADING!
    }

    private async UniTask<ChatMessage> SendGPTRequest(string messageText)
    {
        var wordsAmount = _gameContext.WordsAmount.Value;
        
        Debug.Log($"Making GPT request with message - {messageText} and words amount - {wordsAmount}");
        
        var tunedRequestMessage = $"Imagine I am playing game alias. Give me {wordsAmount} words for the topic {messageText} as an array of string in JSON format with language ru-RU";

        List<ChatMessage> myMessages = new List<ChatMessage>();

        var newMessage = new ChatMessage()
        {
            Role = "user",
            Content = tunedRequestMessage,
        };
        
        myMessages.Add(newMessage);
        
        // Complete the instruction
        var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
        {
            Model = "gpt-3.5-turbo-0613",
            Messages = myMessages,
        });

        if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
        {
            var message = completionResponse.Choices[0].Message;
            message.Content = message.Content.Trim();
            return message;
        }
        else
        {
            Debug.LogWarning("No text was generated from this prompt.");
        }

        return ChatMessage.Empty;
    }

    private List<string> TryParseMessage(string message)
    {
        //ParseResult result = new ParseResult();
        JObject jsonObject = new JObject();
        List<string> results = new List<string>();

        string pattern = @"\{(?:[^{}]|(?<open>\{)|(?<-open>\}))+(?(open)(?!))\}";

        var match = Regex.Match(message, pattern);

        try
        {
            // Parse the JSON into a JObject
            jsonObject = JObject.Parse(match.Value);
        }
        catch (JsonException e)
        {
            Debug.Log(e);
            ErrorController.Instance.ShowError();
            return null;
        }

        if (!jsonObject.HasValues)
        {
            return null;
        }

        // Get the property names dynamically
        foreach (var property in jsonObject.Properties())
        {
            if (!property.HasValues)
            {
                ErrorController.Instance.ShowError();
                break;
            }
            JArray jsonArray = (JArray)property.Value;

            foreach (var value in jsonArray)
            {
                results.Add(value.ToString());
            }
        }

        return results;
    }
}