# Numele Aplicației

O scurtă descriere a aplicației: Aplicația StockManagement este o soluție software proprietară destinată să eficientizeze și să automatizeze workflow-ul companiilor, facilitând managementul stocurilor, produselor, angajaților și comenzilor către furnizori.

## Funcționalități Principale

- **Crearea și Gestionearea de Stocuri**: Permite utilizatorilor să gestioneze eficient stocurile.
- **Crearea și Gestionearea de Produse**: Oferă posibilitatea de a crea și administra produse.
- **Crearea și Gestionearea de Angajati**: Facilitează managementul informațiilor despre angajați, creare si asignare de permisiuni(roles).
- **Crearea și Gestionearea de Comenzi către furnizori**: Simplifică procesul de plasare și urmărire a comenzilor, implementand si o extensie mobila de scanare coduri QR pentru validarea instanta a comenzilor.

## Tehnologii Utilizate

- **Frontend**: React, SAAS
- **Backend**: .NET cu C#
- **API**: REST API
- **Baza de Date**: MySQL heroku vps

## Cerințe Proiect

- [x] **6 Controllere**: Fiecare cu metode CRUD, interacțiune RESTful cu baza de date.
- [x] **Relații între Tabele**: Implementarea tuturor tipurilor de relații (One to One, Many to Many, One to Many) și folosirea metodelor din Linq (GroupBy, Where etc.) plus Join și Include.
- [x] **Autentificare și Autorizare**: Implementare cu Identity, incluzând roluri diferite (Admin, AngajatTier1, AngajatTier2, AngajatTier3) și autorizare pe endpoint-uri în funcție de roluri.
- [x] **Repository Pattern**: Utilizat pentru abstractizarea stratului de acces la date.
- [x] **SMTP Integration**: Integrare cu (formerly) SendinBlue (acum Brevo) pentru trimiterea de e-mailuri.
- [x] **Authentificare cu Refresh Token**: Implementare pentru securitate sporită si ease-of-login
- [x] **Paginare**: În returnarea listelor de date pentru a îmbunătăți performanța.
- [x] **CI/CD**: Utilizare GitHub Actions pentru integrare continuă și desfășurare continuă, cu hostare pe un VPS (AWS/MS Azure/Heroku/DigitalOcean).

## Componente React


1. Dashboard
Pagina principală a aplicației, cunoscută sub numele de Dashboard, oferă o vizualizare de ansamblu asupra funcțiilor principale și permite accesul rapid la diferite secțiuni ale aplicației. Elementele de interfață includ icoane reprezentative pentru fiecare categorie principală: Angajați, Produse, Comenzi și Stocuri. Acesta servește ca hub central pentru navigarea în aplicație, permițând utilizatorilor să acceseze rapid funcționalitățile dorite.
Important -> Avem o functie de search pentru functiile aplicatiei pentru acces rapid si ease-of-use
<img width="172" alt="Screenshot 2024-02-05 at 23 18 34" src="https://github.com/SoftNestSol/StockManagement/assets/84620187/54129279-88f6-477b-9c5b-dca6ed0c5cc4">


3. Pagina de Angajați (AngajatController)
Această pagină este dedicată gestionării angajaților și include funcționalități pentru a vizualiza toți angajații (Get Employees), adăugarea unui nou angajat (Add Employee) și ștergerea unui angajat existent (Delete Employee). Interfața este simplă și directă, cu butoane pentru fiecare acțiune și o listă care afișează angajații existenți, probabil cu ID-ul și numele lor, oferind o interfață clară și ușor de utilizat pentru managementul angajaților.

4. Pagina de Stocuri (Stock Options) - exemplu, toate urmaresc aceeasi structura
Pagina de Stocuri este un instrument esențial pentru managementul inventarului. Aici utilizatorii pot vedea stocurile existente, cu detalii precum ID-ul și locația (e.g., București, Târgoviște, Ploiești). Există, de asemenea, opțiuni pentru colapsarea listei de stocuri pentru o vizualizare simplificată, adăugarea unui nou stoc (Add Stock) și alte acțiuni relevante pentru managementul stocurilor. Designul este intuitiv, oferind o navigare ușoară și eficientă în procesul de gestionare a inventarului.
  
## Autentificare

Autentificarea foloseste JWT pentru usurinta comunicarii client-server si pastrarea sesiunii de logare a utilizatorului curent, folosind LocalStorage. Identity pe partea de server, folosim 4 feluri de roluri pentru a gestiona permisiunile angajatilor.

## Prezentarea Funcționalității (Imagini)
- ![Diagrama ERD BD]
- (https://github.com/SoftNestSol/StockManagement/assets/84620187/7ea388d5-858e-4df6-8d44-ef27b6fb1009)
- ![Pagina Produse]
- (https://github.com/SoftNestSol/StockManagement/assets/84620187/ae77126d-8dde-4803-b102-2ac2b36ed5d6)
  <h3>Pagina Dashboard</h3>
- ![](https://github.com/SoftNestSol/StockManagement/assets/84620187/090c56cc-b323-4931-85ce-7be95810e8be)



## Licență

Standard MIT License
