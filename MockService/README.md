#  Requirements

Er is 1 package die ik niet lokaal bij dit project geïnstalleerd kreeg en was alleen globaal te installeren.

`dotnet tool install --global dotnet-ef`

Let op je moet dan wel .NET op je PC hebben staan, maar dat moet sws wel.

# Migrations

Op het moment gebruikt ik postgres (docker compose inbegrepen), want MSSQL werkt niet op ARM. Wil je voor de Mock heel graag MSSQL gebruiken, dan moet je `MockService/Program.cs` aanpassen.
Dat moet dan NpSql worden, zie de documentatie voor de juiste connection string, te vinden in de app settings.

Gebruik je een andere DB, doe dan eerst `dotnet ef migrations add Initial --project=MockService`.
Dit maakt een migration aan voor jouw DB.

Om de database te updaten doe `dotnet ef database update --projectMockService`.

Elke keer als je een model aanpast, nieuwe migration maken en verwerken naar de db. Of doe het handmatig...

**LET OP:** zorg dat je project niet aan het draaien is, anders werkt het niet.