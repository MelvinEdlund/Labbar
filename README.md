# Labbar till NEU25G

## [Labb 1 – Algoritmer](https://github.com/MelvinEdlund/Labbar/tree/master/Labb1_Algoritmer)
Det här är min första inlämningsuppgift i Programmering med C#, ungefär tre veckor in i kursen. (September 2024)
Jag började precis komma in i hur man kan använda arrayer, loopar och villkor i C# och det här var ett bra sätt att träna.  

### Uppgift
- Programmet ber användaren mata in en text i konsolen.  
- Strängen söks igenom efter delsträngar som:  
  - Börjar och slutar på samma siffra.  
  - Bara innehåller siffror (inga bokstäver eller andra tecken).  
  - Start- och slutsiffran får inte förekomma någonstans mitt i talet.  
- Varje delsträng som matchar skrivs ut och markeras i färg.  
- Alla hittade tal adderas ihop och totalsumman skrivs ut sist.

  **Exempel på output**  
![Exempel på output](bilder/labb1.png)

---

## [Labb 2 – Objektorienterad Programmering](https://github.com/MelvinEdlund/Labbar/tree/master/Labb2_Objektorienterad_Programmering)
Detta är min andra inlämningsuppgift (Oktober 2024).  

Projektet är en förenklad version av ett dungeon crawler-spel i konsolen där spelaren rör sig i en bana med väggar och fiender.  

## Funktioner
- **Banlayout:** Läser in en fördefinierad bana från en textfil med väggar, spelare och fiender (råttor och ormar).  
- **Klasshierarki:** Använder en abstrakt basklass `LevelElement` med subklasser för väggar och fiender.  
- **Spelloop:** Hanterar spelarens och fiendernas drag i en loop med förflyttning, attacker och strider.  
- **Sikt:** Spelarens synfält är begränsat till en radie på 5 enheter. Väggar som en gång upptäckts förblir synliga.  
- **Tärningsmekanik:** Använder tärningsslag för attack och försvar, där spelare och fiender gör skada baserat på resultat.  
- **Rörelsemönster:**  
  - Spelaren styrs av inmatning.  
  - Råttor rör sig slumpmässigt.  
  - Ormar försöker fly från spelaren om denne kommer för nära.  

## Screenshots
**Mitt i banan – strid med en orm:**  
![Strid mot orm](bilder/labb2_1.png)  

**Slutet av banan – hela kartan synlig:**  
![Hela banan](bilder/labb2_2.png)  

**Game Over – när spelaren förlorar:**  
![Game Over](bilder/labb2_3.png) 

## Syfte
Projektet fokuserar på objektorienterade principer som arv, abstraktion och kodåteranvändning.  
