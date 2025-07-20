using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
    public int Playerid { get; set; }

    [Column("playercategories")] // Use your actual column name here
    public PlayerCategories Playercategories { get; set; }

    public string? Playername { get; set; }

    public string? Firstname { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int? Visits { get; set; }
    public int? DurationInSeconds { get; set; }

    public bool? Isplaying { get; set; }

    public bool? Iswaiting { get; set; }

    public bool? Isselectable { get; set; }

    public bool? Isfacilitator { get; set; }

    public bool? Ischoosing { get; set; }

    public bool? Istimeout { get; set; }

    public bool? Warmingup { get; set; }
    public bool? Ischosen { get; set; }

    public bool? Isadmin { get; set; }
    public bool? Attendingsession { get; set; }

    public bool? NeedsSync { get; set; }

    public string? Grade { get; set; }

    public int? Gamescount { get; set; }

    public int? Courtno { get; set; }

    public string? Startedat { get; set; }

    public string? Finishedat { get; set; }

    public int? Orderofplay { get; set; }

    public string? Squareid { get; set; }

    public int? Gameid { get; set; }

    public DateTime? Firstvisit { get; set; }

    public DateTime? Lastvisit { get; set; }

    public bool? Notified { get; set; }


}



