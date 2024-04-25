var list_emp = document.getElementById('listemployer');
var td_nom_prenom = document.getElementById('nom_prenom');
var td_matricule = document.getElementById('matricule');
var td_fonction = document.getElementById('fonction');
var salaire_de_base = document.getElementById('salaire_de_base');
var taux_journaliers = document.getElementById('taux_journaliers');
var taux_horaire = document.getElementById('taux_horaire');
var date_debut = document.getElementById('date_debut');
var date_fin = document.getElementById('date_fin');
var montant_du_salaire_du_date = document.getElementById('montant_du_salaire_du_date');
var salaire_taux = document.getElementById('salaire_taux');
var salaire_montant = document.getElementById('salaire_montant');
var sup_30_nombre = document.getElementById('sup_30_nombre');
var sup_30_taux = document.getElementById('sup_30_taux');
var sup_30_montant = document.getElementById('sup_30_montant');
var sup_40_nombre = document.getElementById('sup_40_nombre');
var sup_40_taux = document.getElementById('sup_40_taux');
var sup_40_montant = document.getElementById('sup_40_montant');
var sup_50_nombre = document.getElementById('sup_50_nombre');
var sup_50_taux = document.getElementById('sup_50_taux');
var sup_50_montant = document.getElementById('sup_50_montant');
var sup_100_nombre = document.getElementById('sup_100_nombre');
var sup_100_taux = document.getElementById('sup_100_taux');
var sup_100_montant = document.getElementById('sup_100_montant');
var maj_heure_nuit_nombre = document.getElementById('maj_heure_nuit_nombre');
var maj_heure_nuit_taux = document.getElementById('maj_heure_nuit_taux');
var maj_heure_nuit_montant = document.getElementById('maj_heure_nuit_montant');
var rappel_per_ant_nombre = document.getElementById('rappel_per_ant_nombre');
var rappel_per_ant_taux = document.getElementById('rappel_per_ant_taux');
var rappel_per_ant_montant = document.getElementById('rappel_per_ant_montant');
var droit_preavis_nombre = document.getElementById('droit_preavis_nombre');
var droit_preavis_taux = document.getElementById('droit_preavis_taux');
var droit_preavis_montant = document.getElementById('droit_preavis_montant');
var absence_nombre = document.getElementById('absence_nombre');
var absence_taux = document.getElementById('absence_taux');
var absence_montant = document.getElementById('absence_montant');
var nombre_salaire_brut = document.getElementById('nombre_salaire_brut');
var ind_licenc_nombre = document.getElementById('ind_licenc_nombre');
var ind_licenc_taux = document.getElementById('ind_licenc_taux');
var ind_licenc_montant = document.getElementById('ind_licenc_montant');
var droit_conge_nombre = document.getElementById('droit_conge_nombre');
var droit_conge_taux = document.getElementById('droit_conge_taux');
var droit_conge_montant = document.getElementById('droit_conge_montant');
var retenue_cnaps = document.getElementById('retenue_cnaps');
var retenue_sanitaire = document.getElementById('retenue_sanitaire');
var tranche_5 = document.getElementById('tranche_5');
var tranche_10 = document.getElementById('tranche_10');
var tranche_15 = document.getElementById('tranche_15');
var tranche_20 = document.getElementById('tranche_20');
var montant_impossable = document.getElementById('montant_impossable');
var total_irsa = document.getElementById('total_irsa');
var total_retenue = document.getElementById('total_retenue');
var net_payer = document.getElementById('net_payer');
var date_fiche = document.getElementById('date_fiche');


var salaire_de_base_n = 0;
var taux_journaliers_n = 0;
var taux_horaire_n = 0;
var taux_horaire_n = 0;
var date_debut_n = 0;
var date_fin_n = 0;
var montant_du_salaire_du_date_n = 0;
var salaire_taux_n = 0;
var salaire_montant_n = 0;
var sup_30_montant_n = 0;
var sup_30_nombre_n = 0;
var sup_30_taux_n = 0;
var sup_40_montant_n = 0;
var sup_40_nombre_n = 0;
var sup_40_taux_n = 0;
var sup_50_montant_n = 0;
var sup_50_nombre_n = 0;
var sup_50_taux_n = 0;
var sup_100_montant_n = 0;
var sup_100_nombre_n = 0;
var sup_100_taux_n = 0;
var maj_heure_nuit_montant_n = 0;
var maj_heure_nuit_nombre_n = 0;
var maj_heure_nuit_taux_n = 0;
var rappel_per_ant_montant_n = 0;
var rappel_per_ant_nombre_n = 0;
var rappel_per_ant_taux_n = 0;
var droit_preavis_montant_n = 0;
var droit_preavis_nombre_n = 0;
var droit_preavis_taux_n = 0;
var absence_montant_n = 0;
var absence_nombre_n = 0;
var absence_taux_n = 0;
var ind_licenc_montant_n = 0;
var ind_licenc_nombre_n = 0;
var ind_licenc_taux_n = 0;
var droit_conge_montant_n = 0;
var droit_conge_nombre_n = 0;
var droit_conge_taux_n = 0;
var nombre_salaire_brut_n = 0;
var retenue_cnaps_n = 0;
var retenue_sanitaire_n = 0;
var tranche_5_n = 0;
var tranche_10_n = 0;
var tranche_15_n = 0;
var tranche_20_n = 0;
var montant_impossable_n = 0 ;
var total_irsa_n = 0;
var total_retenue_n = 0;
var net_payer_n=0;


function arrondiEnMilliersAvecEspace(nombre) {
    // Arrondi le nombre à l'entier le plus proche
    let nombreArrondi = Math.round(nombre);
  
    // Formate le nombre sans séparateur de milliers (utilisation de 'useGrouping')
    let nombreFormateSansSeparateur = nombreArrondi.toLocaleString(undefined, { useGrouping: false });
  
    // Remplace les virgules par des espaces
    let nombreFormateAvecEspace = nombreFormateSansSeparateur.replace(/,/g, ' ');
    nombreFormateAvecEspace = nombreFormateAvecEspace.toLocaleString("fr-FR");
  
    return nombreFormateAvecEspace;
  }
  

function submitForm(matriculeEmp,dateFiche) { 
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/ficheDePaixDetailAjax", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function () {
        if (xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);   
            console.log(response);   
            td_nom_prenom.textContent = response.employer.firstName+" "+response.employer.lastName;
            td_matricule.textContent = response.employer.matricule;
            td_fonction.textContent = response.employer.fonction;

            salaire_de_base_n = response.salaireDeBase;
            taux_journaliers_n = salaire_de_base_n/30;
            taux_horaire_n = salaire_de_base_n/173.33;
            
            date_debut_n = response.dateDebut;
            date_fin_n = response.dateFin;

            montant_du_salaire_du_date_n = salaire_de_base_n;
            salaire_taux_n = taux_journaliers_n;
            salaire_montant_n = salaire_de_base_n;
            sup_30_nombre_n = response.heureSup30;
            sup_40_nombre_n = response.heureSup40;
            sup_50_nombre_n = response.heureSup50;
            sup_100_nombre_n = response.heureSup100;
            maj_heure_nuit_nombre_n = response.majorationHeureNuit;
            rappel_per_ant_nombre_n = response.rappelsPeriodeAnterieure;
            droit_preavis_nombre_n = response.droitPreavis;
            absence_nombre_n = response.joursAbsence;    
            ind_licenc_nombre_n = response.indemniteDeLicenciement;
            droit_conge_nombre_n = response.droitConge;

            sup_30_taux_n = taux_horaire_n*1.3;
            sup_30_montant_n = sup_30_nombre_n*sup_30_taux_n;
            sup_40_taux_n = taux_horaire_n*1.4;
            sup_40_montant_n = sup_40_nombre_n*sup_40_taux_n;
            sup_50_taux_n = taux_horaire_n*1.5;
            sup_50_montant_n = sup_50_nombre_n*sup_50_taux_n;
            sup_100_taux_n = taux_horaire_n*2;
            sup_100_montant_n = sup_100_nombre_n*sup_100_taux_n;
            maj_heure_nuit_taux_n = taux_horaire_n*0.3;
            maj_heure_nuit_montant_n = maj_heure_nuit_nombre_n*maj_heure_nuit_taux_n;
            rappel_per_ant_taux_n = taux_journaliers_n;
            rappel_per_ant_montant_n = rappel_per_ant_taux_n*rappel_per_ant_nombre_n;
            droit_preavis_taux_n = taux_journaliers_n;
            droit_preavis_montant_n = droit_preavis_taux_n*droit_preavis_nombre_n;
            absence_taux_n = taux_journaliers_n;
            absence_montant_n = absence_nombre_n*absence_taux_n;
            ind_licenc_taux_n = taux_journaliers_n;
            ind_licenc_montant_n = ind_licenc_taux_n*ind_licenc_nombre_n;
            droit_conge_taux_n = taux_journaliers_n;
            droit_conge_montant_n = droit_conge_nombre_n*droit_conge_taux_n;
            retenue_sanitaire_n = salaire_de_base_n*0.1;
            tranche_5_n = (50000*5)/100;
            tranche_10_n = (100000*10)/100;
            tranche_15_n = (100000*15)/100;
            nombre_salaire_brut_n = parseInt(salaire_montant_n)+absence_montant_n+sup_30_montant_n+sup_40_montant_n+sup_50_montant_n+sup_100_montant_n+maj_heure_nuit_montant_n+
            rappel_per_ant_montant_n+droit_conge_montant_n+droit_preavis_montant_n+ind_licenc_montant_n;
            if ((nombre_salaire_brut_n*1)/100<20000) {
                retenue_cnaps_n = (nombre_salaire_brut_n*1)/100;
            }else{
                retenue_cnaps_n = 20000;
            }
            montant_impossable_n = nombre_salaire_brut_n-retenue_cnaps_n-retenue_sanitaire_n
            tranche_20_n = ((montant_impossable_n-600000)*20)/100;

            total_irsa_n = tranche_5_n+tranche_10_n+tranche_15_n+tranche_20_n;
            total_retenue_n = total_irsa_n+retenue_cnaps_n+retenue_sanitaire_n;
            net_payer_n = nombre_salaire_brut_n+total_retenue_n;

            salaire_de_base.textContent = arrondiEnMilliersAvecEspace(salaire_de_base_n);
            taux_journaliers.textContent = arrondiEnMilliersAvecEspace(taux_journaliers_n);
            taux_horaire.textContent = arrondiEnMilliersAvecEspace(taux_horaire_n);
            date_debut.textContent = date_debut_n;
            date_fin.textContent = date_fin_n;
            montant_du_salaire_du_date.textContent = arrondiEnMilliersAvecEspace(montant_du_salaire_du_date_n);
            salaire_taux.textContent = arrondiEnMilliersAvecEspace(salaire_taux_n);
            salaire_montant.textContent = arrondiEnMilliersAvecEspace(salaire_montant_n);
            sup_30_taux.textContent = arrondiEnMilliersAvecEspace(sup_30_taux_n);
            sup_30_montant.textContent = arrondiEnMilliersAvecEspace(sup_30_montant_n);
            sup_30_nombre.textContent = arrondiEnMilliersAvecEspace(sup_30_nombre_n);
            sup_40_taux.textContent = arrondiEnMilliersAvecEspace(sup_40_taux_n);
            sup_40_montant.textContent = arrondiEnMilliersAvecEspace(sup_40_montant_n);
            sup_40_nombre.textContent = arrondiEnMilliersAvecEspace(sup_40_nombre_n);
            sup_50_taux.textContent = arrondiEnMilliersAvecEspace(sup_50_taux_n);
            sup_50_montant.textContent = arrondiEnMilliersAvecEspace(sup_50_montant_n);
            sup_50_nombre.textContent = arrondiEnMilliersAvecEspace(sup_50_nombre_n);
            sup_100_taux.textContent = arrondiEnMilliersAvecEspace(sup_100_taux_n);
            sup_100_montant.textContent = arrondiEnMilliersAvecEspace(sup_100_montant_n);
            sup_100_nombre.textContent = arrondiEnMilliersAvecEspace(sup_100_nombre_n);
            maj_heure_nuit_montant.textContent = arrondiEnMilliersAvecEspace(maj_heure_nuit_montant_n);
            maj_heure_nuit_nombre.textContent = arrondiEnMilliersAvecEspace(maj_heure_nuit_nombre_n);
            maj_heure_nuit_taux.textContent = arrondiEnMilliersAvecEspace(maj_heure_nuit_taux_n);
            rappel_per_ant_montant.textContent = arrondiEnMilliersAvecEspace(rappel_per_ant_montant_n);
            rappel_per_ant_nombre.textContent = arrondiEnMilliersAvecEspace(rappel_per_ant_nombre_n);
            rappel_per_ant_taux.textContent = arrondiEnMilliersAvecEspace(rappel_per_ant_taux_n);
            droit_preavis_montant.textContent = arrondiEnMilliersAvecEspace(droit_preavis_montant_n);
            droit_preavis_nombre.textContent = arrondiEnMilliersAvecEspace(droit_preavis_nombre_n);
            droit_preavis_taux.textContent = arrondiEnMilliersAvecEspace(droit_preavis_taux_n);
            absence_montant.textContent = arrondiEnMilliersAvecEspace(absence_montant_n);
            absence_nombre.textContent = arrondiEnMilliersAvecEspace(absence_nombre_n);
            ind_licenc_taux.textContent = arrondiEnMilliersAvecEspace(ind_licenc_taux_n);
            ind_licenc_montant.textContent = arrondiEnMilliersAvecEspace(ind_licenc_montant_n);
            ind_licenc_nombre.textContent = arrondiEnMilliersAvecEspace(ind_licenc_nombre_n);
            absence_taux.textContent = arrondiEnMilliersAvecEspace(absence_taux_n);
            droit_conge_taux.textContent = arrondiEnMilliersAvecEspace(droit_conge_taux_n);
            droit_conge_montant.textContent = arrondiEnMilliersAvecEspace(droit_conge_montant_n);
            droit_conge_nombre.textContent = arrondiEnMilliersAvecEspace(droit_conge_nombre_n);
            nombre_salaire_brut.textContent = arrondiEnMilliersAvecEspace(nombre_salaire_brut_n);
            retenue_cnaps.textContent = arrondiEnMilliersAvecEspace(retenue_cnaps_n);
            retenue_sanitaire.textContent = arrondiEnMilliersAvecEspace(retenue_sanitaire_n);
            tranche_5.textContent = arrondiEnMilliersAvecEspace(tranche_5_n);
            tranche_10.textContent = arrondiEnMilliersAvecEspace(tranche_10_n);
            tranche_15.textContent = arrondiEnMilliersAvecEspace(tranche_15_n);
            tranche_20.textContent = arrondiEnMilliersAvecEspace(tranche_20_n);
            montant_impossable.textContent = arrondiEnMilliersAvecEspace(montant_impossable_n);
            total_irsa.textContent = arrondiEnMilliersAvecEspace(total_irsa_n);
            total_retenue.textContent = arrondiEnMilliersAvecEspace(total_retenue_n);
            net_payer.textContent = arrondiEnMilliersAvecEspace(net_payer_n);

            
        }
    };
    const dataToSend = {
        matricule : matriculeEmp,
        date_debut : dateFiche,
    };
    xhr.send(JSON.stringify(dataToSend));
}

// Ajoutez un gestionnaire d'événements pour le changement de sélection
function validation() {
    // Récupérez les valeurs sélectionnées
    const matriculeEmp = list_emp.value;
    const dateFiche = date_fiche.value;
    //Appelez la fonction submitForm avec les valeurs en tant qu'arguments
    // salaire_de_base.textContent = "response.employer.salaireDeBase;"
    submitForm(matriculeEmp,dateFiche);
}
function getDate() {
    const matricule_emp = list_emp.value;
    searchDateAjax(matricule_emp);
}
var mettreBalise = function(bMetre,bNouvelle) {
	bMetre.appendChild(bNouvelle);
	return bMetre;
}
function searchDateAjax(matriculeEmp) { 
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/date_fiche", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function () {
        if (xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);
            console.log(response);
            while (date_fiche.firstChild) {
                date_fiche.removeChild(date_fiche.firstChild);
            }
            for (let index = 0; index < response.length; index++) {
                var optione = document.createElement('option');
                optione.value = response[index];
                optione.textContent = response[index];
                date_fiche = mettreBalise(date_fiche,optione);
            }
        }
    };
    const dataToSend = {
        matricule : matriculeEmp,
    };
    xhr.send(JSON.stringify(dataToSend));
}
