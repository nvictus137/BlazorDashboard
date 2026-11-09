using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BlazorDashboard.Shared.Helpers.QuickType;

public partial class Errors
{
    [JsonProperty("Email")]
    public string[] Email { get; set; }

    [JsonProperty("Title")]
    public string[] Title { get; set; }

    [JsonProperty("Password")]
    public string[] Password { get; set; }

    [JsonProperty("FirstName")]
    public string[] FirstName { get; set; }

    [JsonProperty("ConfirmPassword")]
    public string[] ConfirmPassword { get; set; }
}
