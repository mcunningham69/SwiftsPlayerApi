using System;
using System.Text.Json.Serialization;

namespace SwiftsPlayerApi.Models;

public class PlayerStatusDTO
{
    [JsonPropertyName("uuid")]
    public Guid Uuid { get; set; }

    [JsonPropertyName("playername")]
    public string? Playername { get; set; }

    [JsonPropertyName("firstname")]
    public string? Firstname { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("visits")]
    public int? Visits { get; set; }

    [JsonPropertyName("isplaying")]
    public bool? Isplaying { get; set; }

    [JsonPropertyName("iswaiting")]
    public bool? Iswaiting { get; set; }

    [JsonPropertyName("isselectable")]
    public bool? Isselectable { get; set; }

    [JsonPropertyName("isfacilitator")]
    public bool? Isfacilitator { get; set; }

    [JsonPropertyName("ischoosing")]
    public bool? Ischoosing { get; set; }

    [JsonPropertyName("istimeout")]
    public bool? Istimeout { get; set; }

    [JsonPropertyName("warmingup")]
    public bool? Warmingup { get; set; }

    [JsonPropertyName("grade")]
    public string? Grade { get; set; }


    [JsonPropertyName("changed_by")]
    public string? Changed_by { get; set; }

    [JsonPropertyName("gamescount")]
    public int? Gamescount { get; set; }

    [JsonPropertyName("ischosen")]
    public bool? Ischosen { get; set; }

    [JsonPropertyName("isadmin")]
    public bool? Isadmin { get; set; }

    [JsonPropertyName("courtno")]
    public int? Courtno { get; set; }

    [JsonPropertyName("attendingsession")]
    public bool? Attendingsession { get; set; }

    [JsonPropertyName("startedat")]
    public string? Startedat { get; set; }

    [JsonPropertyName("finishedat")]
    public string? Finishedat { get; set; }

    [JsonPropertyName("orderofplay")]
    public int? Orderofplay { get; set; }

    [JsonPropertyName("squareid")]
    public string? Squareid { get; set; }

    [JsonPropertyName("gameid")]
    public int? Gameid { get; set; }

    [JsonPropertyName("playercategories")]
    public int Playercategories { get; set; }

    [JsonPropertyName("durationinseconds")]
    public int? DurationInSeconds { get; set; }

    [JsonPropertyName("notified")]
    public bool? Notified { get; set; }

    [JsonPropertyName("needsSync")]
    public bool? NeedsSync { get; set; }
}

