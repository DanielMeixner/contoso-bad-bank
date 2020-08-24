# Contoso BadBank Hackathon


## Hintergrund/Narrativ:
Das ist die Ausgangslage: Einer Deiner Entwickler hat die Firma verlassen und Quellcode hinterlassen für eine Aktiondepot Anwendung. Deine Aufgabe ist es, den Code zu übernehmen, zum Laufen zu bringen und die Anwendung zu erweitern.
Unten findest Du eine Liste von Aufgaben, die Dich anleiten die App zum Laufen zu bekommen und nach und nach mit Featuren anzureichern - und letztlich die Cloud voll auszunutzen.


## Kernprinzipien:
In Azure gibt es viele Wege Dinge umzusetzten. Für welchen Weg Du Dich entscheidest, liegt an Dir, aber halte folgende Prinzipien im Hinterkopf.
- verwende existierende Bausteine und Services in Azure und erfinde das Rad nicht neu
- versuch Dinge zu lösen ohne Code zu schreiben, wo es möglich ist - manchmal kann man Dinge einfach konfigurieren
- Achte auf Kosteneffizienz!
- Vermeide Fixkosten und bevorzuge ein Consumption-Model


## Hinweis:
>Das Szenario kommt aus der Finanzindustrie aber es handelt sich hier natürlich lediglich um ein Demoprojekt. Für den produktiven Einsatz sollten weitere Anpassungen vorgenommen werden.



### 1	Bring den Code zum Laufen
Bring den Code auf Azure zum Laufen. Du findest den Code hier: https://github.com/DanielMeixner/contoso-bad-bank

1.	Schau Dir den Anwendungscode an und versuche ihn zu verstehen
2.	Such eine passende Lösung den Code auf Azure auszuführen.
3.	Führe den Code aus und greife auf die Website zu.

> Abnahmekriterium: Die Applikation läuft und Du kannst vom Browser aus auf die Website zugreifen.

### 2	Identitäten
Die Applikation ist schon vorbereitet um mit einer Identitätsmanagement Lösung zu arbeiten, aber Du kannst Dich noch nicht einloggen.

4.	Finde eine Lösung Identitäten Deiner Nutzer zu managen.  
5.	Verbinde Deine App mit dem Identity Management.
6.	Beim Anlegen eines neuen Nutzers, frage Name, Emailadresse, Telefonnummer ab.

> Erfolgskriterium: Neue Nutzer könnens sich eintragen und an der App anmelden und die geforderten Werte werden abgefragt.

### 3	Anwendungsdaten
Nutzer möchten Aktienhandel im Depot betreiben. Stelle sicher, dass neue Aufträge abgegeben werden können. (Für Demozwecke lassen wir Aktienkurs, Limits, Gültigkeit, Börse etc außen vor).
> Erfolgskriterium: Nutzer können Aufträge abgeben (zB "Kaufe 10 MSFT Aktien"), die Aufträge sind danach in der "Orders" Seite sichtbar.

7.	Die Aufträge müssen irgendwo persistäent gespeichert werden, suche nach einer guten Speichermöglichkeit. Die Daten sollten mindestens diese Informationen beinhalten.:
    *	Stock Symbol (zB MSFT)
    *	Anzahl der Aktien
    *	Datum und Zeit
    *	Zustand des Auftrags (open, processing, executing)


### 4	Asynchrone Ausführung
Die Aufträge müssen natürlich auch ausgeführt werden. (Für Demozwecke können Aktienkurs, Limits, Gültigkeit, Börse etc außen vor gelassen werden)

> Erfolgskriterium: Die Aufträge werden ausgeführt und der Status ändert sich - nach einiger Zeit - von  “open” auf “executed” 

12.	Implementiere einen Service, der die Aufträge ausführt und den Status ändert. Die Technologie ist egal, aber denke an die Kernprinzipien bei der Technologogiewahl. 
13.	Hinterlege die Information zu Käufen und Verkäufen pro Nutzer:
    *	Anzahl der Aktien 
    *	Stock Symbol
14.	Die Ausführung des Auftrags muss asynchron sein!

### 5	Integration
Um das Geschäftsmodell zu erweitern wird entschieden, dass über APIs Zugriff auf bestimmte Daten auch für Dritthersteller möglich sein soll. Erstelle einen Service, der Zugriff auf die Datenbank erlaubt. Die API soll die Gesamtanzahl der Aufträge pro Tag zur Verfügung stellen.

> Erfolgskriterium:

    •	Ein Entwickler eines Drittherstellers kann eine API aufrufen, die den gewünschten Wert liefert. Die API Aufrufe müssen sich im Rahmen der Quota bewegen. 
    •	Ein Entwickler eines Drittherstellers kann eine "Subscription" für den API Zugriff anfordern.           
    •	Ein Entwickler eines Drittherstellers kann sich eine Doku ansehen, die beschreibt, wie die API zu verwenden ist.

15.	Implementiere einen Dienst, der auf die Daten zugreift. Die Technologie ist egal, aber denke an die Kernprinzipien bei der Technologogiewahl.
16.	Stelle eine API zur Verfügung, die nur mit einem gültigen Key aufgefurfen werden kann, der nur Entwicklern mit gültigen Subscriptions zur Verfügung steht.
17.	Limitiere die Anzahl der zugelassenen Aufrufe auf 5 pro Minute.
18.	Sorge dafür, dass Entwickler sehr komfortable die API benutzen können und eine Übersicht finden, welche APIs es gibt und wie diese zu verwenden sind. 

### 6	Kommunikation via SMS
Aufgrund von Betrugsfällen entscheidet der CISO, dass nach jeder Transaktion eine SMS mit Bestätigung der erfolgreichen Transaktion an den Kunden verschickt werden soll. 
> Erfolgskriterium: Immer wenn wenn ein Auftrag ausgeführt wurde, wird eine SMS an den Nutzer verschickt. 

19.	Implementiere oder erweitere einen Servcie, der eine SMS Bestätigung an den Nutzer schickt.

### 7	Social Media & Empfehlungsservice
Als neues Feature soll ein Pilot gebaut werden, der Empfehlungen zum Kauf oder Verkauf auf Basis von Stimmungen in Sozialen Netzwerken (Twitter) gegenüber bestimmten Marken macht. Auf Basis der Auswertung der Stimmung (Sentiment) soll eine Empfehlung zum Kauf oder Verkauf abgegeben werden, wenn Kunden die entsprechende Aktien ohnehin schon im Portfolio haben.
> Erfolgskriterium: Ein Kunde sieht ein kleines Icon, das die Stimmung für eine bestimmte Aktie symbolisiert. 

20.	Implementiere einen Service, der Soziale Netzwerke (Twitter) überwacht und nach Beiträgen sucht, die sich auf eine bestimmte Firma beziehen (für die Demo ist eine einzige Firma ausreichend)
21.	Führe eine Sentiment Analyse durch, um den Text des Tweets auswerten zu lassen.
22.	Zeige die Ergebnisse im Depot der Nutzer an.
23.	Update die Auswertung in einem sinnvollen Intervall.

### 8	Continuous Improvements
Jetzt, wo alles läuft, möchtest Du die Anwendung immer wieder mit einer neuen Version updaten.

24.	Erstelle eine separate Instanz der App für Testzwecke, die die Produktionsdaten nicht manipulieren kann.
25.	Installiere eine neue Version Deiner App und sorge dafür, dass es während der Installation keine Downtime für Deine Nutzer gibt.
26.	Versuche einen Weg zu finden, die neue Version nur für 10% der User sichtbar zu machen, während der Rest auf der "alten" Version bleibt. 

### 9	Sicherheit und Verfügbarkeit
27. Dein CISO fordert Multifaktor-Authentication. Stelle sicher dass jeder Nutzer zwei Faktoren angeben muss, bevor er/sie sich einloggen kann.
28.	Deine App ist sehr erfolgreich. Modifiziere sie, so dass die Infrastruktur automatisch skalieren kann, wenn die Last größer wird.
29. Stelle sicher, dass Deine Daten repliziert sind, so dass die Daten nicht verloren sind, wenn ein Datacenter ausfällt.
30.	Bonus: Unter welchen Umständen kann es dennoch Daten Inkonsistenz geben? Wie könnte man das lösen?

### 10	Disaster Recovery 
Nachdem alles initial eingerichtet ist, möchtest Du sicherstellen, dass niemand versehentlich alles wieder kaputt macht, was in Azure angelegt wurde.

29.	Suche nach einem Weg die Erstellung der Azure Infrastruktur zu automatisieren, im besten Falle im Sinne von "Infrastructre as Code".
30.	Packe diesen Code in die Quellcodeverwaltung und versuche eine zweite Instanz Deiner App damit zu erzeugen.

### 11	CI/CD
Automatisiere das Deployment Deiner Applikation, falls noch nicht geschehen, so dass es keine manuellen Schritte mehr gibt.

31.	Erstelle eine Pipeline, die nach jedem Commit die neue Version der Anwendung deployed.

### 12 Extend 

32. Erweitere die App mit Deinen eigenen Ideen (z.B. Preise, UI, ...)



