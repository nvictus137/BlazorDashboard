using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BlazorDashboard.Shared.Helpers.QuickType;


public partial class Welcome
{
    [JsonProperty("type")]
    public Uri Type { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("traceId")]
    public string TraceId { get; set; }

    [JsonProperty("errors")]
    public Errors Errors { get; set; }

    public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
}
