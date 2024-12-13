# Databáze Programovacích Jazyků

## Popis Projektu

Konzolová aplikace pro správu a prohlížení informací z databáze. Umožňuje procházet seznam jazyků, vyhledávat jazyky podle roku vzniku a zobrazovat autory konkrétních programovacích jazyků.

## Požadavky

- .NET 9.0 SDK
- MySQL Server 8.0+
- Nainstalované NuGet balíčky:
  - Microsoft.EntityFrameworkCore
  - Pomelo.EntityFrameworkCore.MySql

## Instalace

### Krok 1: Naklonování repozitáře

```bash
git clone https://github.com/Tekaruxd/prg_koz
cd ./prg_koz/app
```

### Krok 2: Obnovení závislostí

```bash
dotnet restore
```

### Krok 3: Konfigurace databáze

1. Vytvořte databázi `plang` pomocí `create.sql`
2. Upravte connection string v `ProgrammingLanguageContext.cs`
   ```csharp
   "Server=localhost;Database=plang;User=root;Password=;"
   ```

### Krok 4: Spuštění aplikace

```bash
dotnet run
```

## Struktura Projektu

- `Models/`: Definice datových modelů

  - `Language, Author, CreatedBy`: Jednotlivé modely

- `Data/`: Kontext databáze

  - `ProgrammingLanguageContext.cs`: Nastavení Entity Framework

- `Program.cs`: Hlavní aplikační logika

## Funkce

1. Seznam jazyků

   - Zobrazí všechny programovací jazyky seřazené podle roku vzniku

2. Autoři jazyka

   - Umožňuje vyhledat autory konkrétního programovacího jazyka

3. Vyhledávání podle roku
   - Nalezne jazyky vytvořené v zadaném roce

## Databázové Schéma

- Tabulka `lang`: Programovací jazyky
- Tabulka `author`: Autoři jazyků
- Tabulka `createdby`: Propojení jazyků s autory
