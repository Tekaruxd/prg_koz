### Zadání: Implementace databáze programovacích jazyků a aplikačního rozhraní

#### Cíl úlohy

Cílem této úlohy je implementovat databázi pro uchování informací o programovacích jazycích a jejich autorech a vytvořit aplikační rozhraní, které pomocí objektově relačního mapování (ORM) načte a zobrazí autory spojené s konkrétními programovacími jazyky. Studenti mohou využít libovolný programovací jazyk a databázový server.

#### Popis úlohy

1. **Vytvoření databáze**:

   - Použijte SQL skript `create.sql` k vytvoření databáze a tabulek, které budou obsahovat informace o programovacích jazycích, autorech a jejich vztazích.
   - Pro vytvoření databáze použijte databázový server dle vlastního výběru (např. MySQL, PostgreSQL).

2. **Struktura databáze**
   Databáze obsahuje následující tabulky:

   - **`lang`**: Tabulka obsahující informace o programovacích jazycích.
   - **`author`**: Tabulka obsahující informace o autorech programovacích jazyků.
   - **`createdby`**: Propojení mezi programovacími jazyky a autory (relace typu "mnoho k mnoha").

3. **Implementace aplikačního rozhraní**

   - Vytvořte aplikaci, která využívá ORM pro komunikaci s databází. Aplikace by měla umožnit:

     - Načítání programovacích jazyků.
     - Zobrazení autorů spojených s vybraným jazykem.

   - Můžete použít jakýkoli programovací jazyk, který podporuje ORM (např. Python s SQLAlchemy, Java s Hibernate, C# s Entity Framework, apod.).

4. **Požadavky**

   - **Databázový server**: Libovolný databázový server (MySQL, PostgreSQL, SQLite atd.).
   - **Programovací jazyk**: Libovolný jazyk podporující ORM (např. Python, Java, C#).
   - **ORM knihovna**: Libovolná ORM knihovna dle výběru studenta (např. SQLAlchemy, Hibernate, Entity Framework).
   - **Funkce aplikace**:
     - Načítání dat o jazycích a autorech z databáze.
     - Zobrazení seznamu autorů pro konkrétní jazyk.

5. **Příklad zadání pro aplikaci**
   Aplikace by měla umožnit uživateli:
   - Zobrazit seznam programovacích jazyků, které jsou uložené v databázi.
   - Po výběru jazyka zobrazit seznam autorů, kteří jsou s tímto jazykem propojeni.

#### Způsob odevzdání

1. Vytvořte projekt obsahující zdrojový kód programu.
2. Odevzdejte odkaz na svůj projekt v repu na GitHubu.

#### Hodnocení

- Funkčnost aplikace a správnost výstupů.
- Použití objektově relačního mapování pro interakci s databází.
- Kvalita kódu (čitelnost, struktura).

#### Tipy

- Ujistěte se, že databáze je správně nakonfigurována a že jsou vložena potřebná data pro testování aplikace.
- Použijte nástroje pro ladění a testování databázových dotazů.
- Zvažte implementaci jednoduchého uživatelského rozhraní pro snadnější interakci s aplikací.
