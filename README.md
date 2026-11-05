# Daggerheart Party Tool

A party manager for Daggerheart tabletop games, where you keep track of your
characters, their stats, and their attacks. Built for .NET Web Development at WCTC.

**Live:** https://daggerheart-party-tool-zr7968.azurewebsites.net

## What it does

- Browse your whole party as a grid of character cards
- Open a character to see their stats and every attack they have
- Add, edit, and remove characters, and add attacks to any character

## The three things I fixed for the midterm

1. The party list was built inside a `<table>`, which broke the card grid. It now lays out as three columns on desktop (two on tablets, one on phones) and says "1 character" instead of "1 characters."
2. The front page spotlight was hardcoded to character #1, so removing that character left a heading with nothing under it. It now spotlights the first character that exists, and shows a prompt to add one when the party is empty.
3. The character details page had leftover "On the menu" text, showed attacks as `d 8 + 1` (and `+ -2` for negative modifiers), and had no way to navigate away. The heading now says "Attacks," dice read `d8 +1` / `d6 -2` / `d6`, and there are Edit and Back to party buttons.

## Built with

ASP.NET Core MVC (.NET 10), Entity Framework Core, SQL Server, Bootstrap (Bootswatch Zephyr theme).

## Running it locally

The connection string lives in user secrets, not in this repo:

    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your connection string>"
    dotnet ef database update
    dotnet watch