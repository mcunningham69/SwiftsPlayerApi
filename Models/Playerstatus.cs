using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SwiftsPlayerApi.Models;


public enum PlayerCategories
{
    Pending = 0,
    Chosen = 1,
    Playing = 2,
    Waiting = 3
}


public partial class Playerstatus
{
    [Key]
    [JsonPropertyName("uuid")]
    [Column("uuid")]
    public Guid Uuid { get; set; }


    [JsonPropertyName("playercategories")]
    [Column("playercategories")] // Use your actual column name here
    public PlayerCategories Playercategories { get; set; }

    [JsonPropertyName("playername")]
    [Column("playername")]
    public string? Playername { get; set; }

    [JsonPropertyName("firstname")]
    [Column("firstname")]
    public string? Firstname { get; set; }

    [JsonPropertyName("surname")]
    [Column("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("email")]
    [Column("email")]
    public string? Email { get; set; }

    [JsonPropertyName("visits")]
    [Column("visits")]
    public int? Visits { get; set; }

    [JsonPropertyName("durationinseconds")]
    [Column("durationinseconds")]
    public int? DurationInSeconds { get; set; }

    [JsonPropertyName("isplaying")]
    [Column("isplaying")]
    public bool? Isplaying { get; set; }

    [JsonPropertyName("iswaiting")]
    [Column("iswaiting")]
    public bool? Iswaiting { get; set; }

    [JsonPropertyName("isselectable")]
    [Column("isselectable")]
    public bool? Isselectable { get; set; }

    [JsonPropertyName("isfacilitator")]
    [Column("isfacilitator")]
    public bool? Isfacilitator { get; set; }

    [JsonPropertyName("ischoosing")]
    [Column("ischoosing")]
    public bool? Ischoosing { get; set; }

    [JsonPropertyName("istimeout")]
    [Column("istimeout")]
    public bool? Istimeout { get; set; }

    [JsonPropertyName("warmingup")]
    [Column("warmingup")]
    public bool? Warmingup { get; set; }

    [JsonPropertyName("ischosen")]
    [Column("ischosen")]
    public bool? Ischosen { get; set; }

    [JsonPropertyName("isadmin")]
    [Column("isadmin")]
    public bool? Isadmin { get; set; }

    [JsonPropertyName("attendingsession")]
    [Column("attendingsession")]
    public bool? Attendingsession { get; set; }

    [JsonPropertyName("needsSync")]
    [Column("needssync")]
    public bool? NeedsSync { get; set; }

    [JsonPropertyName("grade")]
    [Column("grade")]
    public string? Grade { get; set; }


    [JsonPropertyName("gamescount")]
    [Column("gamescount")]
    public int? Gamescount { get; set; }

    [JsonPropertyName("courtno")]
    [Column("courtno")]
    public int? Courtno { get; set; }


    [JsonPropertyName("startedat")]
    [Column("startedat")]
    public string? Startedat { get; set; }


    [JsonPropertyName("finishedat")]
    [Column("finishedat")]
    public string? Finishedat { get; set; }

    [JsonPropertyName("orderofplay")]
    [Column("orderofplay")]
    public int? Orderofplay { get; set; }


    [JsonPropertyName("squareid")]
    [Column("squareid")]
    public string? Squareid { get; set; }

    [JsonPropertyName("gameid")]
    [Column("gameid")]
    public int? Gameid { get; set; }


    [JsonPropertyName("notified")]
    [Column("notified")]
    public bool? Notified { get; set; }

}