using System;
using SwiftsPlayerApi.Models;   // Update to match where PlayerStatusDTO is

namespace SwiftsPlayerApi.Extensions;
public static class PlayerstatusMapping
{
    public static PlayerStatusDTO ToDTO(this Playerstatus p)
    {
        return new PlayerStatusDTO
        {
            Uuid = p.Uuid,
            Playername = p.Playername ?? "",
            Firstname = p.Firstname ?? "",
            Surname = p.Surname ?? "",
            Email = p.Email ?? "",
            Visits = p.Visits ?? 1,
            Isplaying = p.Isplaying ?? false,
            Iswaiting = p.Iswaiting ?? false,
            Isselectable = p.Isselectable ?? true,
            Isfacilitator = p.Isfacilitator ?? false,
            Ischoosing = p.Ischoosing ?? false,
            Istimeout = p.Istimeout ?? false,
            Warmingup = p.Warmingup ?? true,
            Grade = p.Grade ?? "C1",
            Gamescount = p.Gamescount ?? 0,
            Ischosen = p.Ischosen ?? false,
            Isadmin = p.Isadmin ?? false,
            Courtno = p.Courtno ?? 0,
            Attendingsession = p.Attendingsession ?? false,
            Startedat = p.Startedat ?? "",
            Finishedat = p.Finishedat ?? "",
            Orderofplay = p.Orderofplay ?? 0,
            Squareid = p.Squareid ?? "",
            Gameid = p.Gameid ?? 0,
            Playercategories = (int)p.Playercategories,
            DurationInSeconds = p.DurationInSeconds ?? 0,
            Notified = p.Notified ?? false,
            NeedsSync = p.NeedsSync ?? false
        };

    }

    public static void CopyFromDTO(this Playerstatus target, PlayerStatusDTO source)
    {
        target.Uuid = source.Uuid;
        target.Playername = source.Playername;
        target.Firstname = source.Firstname;
        target.Surname = source.Surname;
        target.Email = source.Email;
        target.Visits = source.Visits;
        target.Isplaying = source.Isplaying;
        target.Iswaiting = source.Iswaiting;
        target.Isselectable = source.Isselectable;
        target.Isfacilitator = source.Isfacilitator;
        target.Ischoosing = source.Ischoosing;
        target.Istimeout = source.Istimeout;
        target.Warmingup = source.Warmingup;
        target.Grade = source.Grade;
        target.Gamescount = source.Gamescount;
        target.Ischosen = source.Ischosen;
        target.Isadmin = source.Isadmin;
        target.Courtno = source.Courtno;
        target.Attendingsession = source.Attendingsession;
        target.Startedat = source.Startedat;
        target.Finishedat = source.Finishedat;
        target.Orderofplay = source.Orderofplay;
        target.Squareid = source.Squareid;
        target.Gameid = source.Gameid;
        target.Playercategories = Enum.IsDefined(typeof(PlayerCategories), source.Playercategories)
        ? (PlayerCategories)source.Playercategories
        : PlayerCategories.Pending;


        target.DurationInSeconds = source.DurationInSeconds;
        target.Notified = source.Notified;
        target.NeedsSync = source.NeedsSync;
    }

    public static Playerstatus ToEntity(this PlayerStatusDTO source)
    {
        var entity = new Playerstatus();
        entity.CopyFromDTO(source);
        return entity;
    }

}

