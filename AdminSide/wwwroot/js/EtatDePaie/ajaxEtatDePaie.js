var date_fiche = document.getElementById('date_fiche');
var body_table = document.getElementById('body_table');
var totaleAPaie = document.getElementById('totale');
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

var totale_etat_de_paie = 0;


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
  

function submitForm(dateFiche) { 
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/getAllFicheByDate", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function () {
        if (xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);   
            console.log(response);
            body_table=supprimerChild(body_table);
            totale_etat_de_paie = 0;
            for (let index = 0; index < response.length; index++) {
                var ligne = document.createElement("tr");
                var matricule = document.createElement("td");
                var prenomEmployeur = document.createElement("td");
                var nomEmployeur = document.createElement("td");
                var genreemployeur = document.createElement("td");
                var directionemployeur = document.createElement("td");
                var fonctionemployeur = document.createElement("td");
                var datededebut = document.createElement("td");
                var datedefin = document.createElement("td");
                var nombredejours = document.createElement("td");
                var salairedebase = document.createElement("td");
                var heuresupplementaire30 = document.createElement("td");
                var heuresupplementaire40 = document.createElement("td");
                var heuresupplementaire50 = document.createElement("td");
                var heuresupplementaire100 = document.createElement("td");
                var primedeRendement = document.createElement("td");
                var primedAnciennete = document.createElement("td");
                var majorationHeureNuit = document.createElement("td");
                var primediverse = document.createElement("td");
                var rappelsperiodeanterieure = document.createElement("td");
                var droitConge = document.createElement("td");
                var droitpreavis = document.createElement("td");
                var indemnitedelicenciement = document.createElement("td");
                var joursdAbsence = document.createElement("td");
                var totaleEmp = document.createElement('td');

                salaire_de_base_n = response[index].salaireDeBase;
                taux_journaliers_n = salaire_de_base_n/30;
                taux_horaire_n = salaire_de_base_n/173.33;
      
                
                date_debut_n = response[index].dateDebut;
                date_fin_n = response[index].dateFin;
    
                montant_du_salaire_du_date_n = salaire_de_base_n;
                salaire_taux_n = taux_journaliers_n;
                salaire_montant_n = salaire_de_base_n;
                sup_30_nombre_n = response[index].heureSup30;
                sup_40_nombre_n = response[index].heureSup40;
                sup_50_nombre_n = response[index].heureSup50;
                sup_100_nombre_n = response[index].heureSup100;
                maj_heure_nuit_nombre_n = response[index].majorationHeureNuit;
                rappel_per_ant_nombre_n = response[index].rappelsPeriodeAnterieure;
                droit_preavis_nombre_n = response[index].droitPreavis;
                absence_nombre_n = response[index].joursAbsence;    
                ind_licenc_nombre_n = response[index].indemniteDeLicenciement;
                droit_conge_nombre_n = response[index].droitConge;
    
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

                totale_etat_de_paie = totale_etat_de_paie+net_payer_n;

                matricule.textContent = response[index].employer.matricule;
                prenomEmployeur.textContent = response[index].employer.lastName;
                nomEmployeur.textContent = response[index].employer.firstName;
                genreemployeur.textContent = response[index].employer.genre;
                directionemployeur.textContent = response[index].employer.direction;
                fonctionemployeur.textContent = response[index].employer.fonction;
                datededebut.textContent = response[index].dateDebut;
                datedefin.textContent = response[index].dateFin;
                nombredejours.textContent = "1 mois";
                salairedebase.textContent = arrondiEnMilliersAvecEspace(salaire_montant_n);
                heuresupplementaire30.textContent = arrondiEnMilliersAvecEspace(sup_30_montant_n);
                heuresupplementaire40.textContent = arrondiEnMilliersAvecEspace(sup_40_montant_n);
                heuresupplementaire50.textContent = arrondiEnMilliersAvecEspace(sup_50_montant_n);
                heuresupplementaire100.textContent = arrondiEnMilliersAvecEspace(sup_100_montant_n);
                majorationHeureNuit.textContent = arrondiEnMilliersAvecEspace(maj_heure_nuit_montant_n);
                rappelsperiodeanterieure.textContent = arrondiEnMilliersAvecEspace(rappel_per_ant_montant_n);
                droitConge.textContent = arrondiEnMilliersAvecEspace(droit_conge_montant_n);
                droitpreavis.textContent = arrondiEnMilliersAvecEspace(droit_preavis_montant_n);
                indemnitedelicenciement.textContent = arrondiEnMilliersAvecEspace(ind_licenc_montant_n);
                totaleEmp.textContent = arrondiEnMilliersAvecEspace(net_payer_n);

                ligne = mettreBalise(ligne,totaleEmp);
                ligne = mettreBalise(ligne,matricule);
                ligne = mettreBalise(ligne,prenomEmployeur);
                ligne = mettreBalise(ligne,nomEmployeur);
                ligne = mettreBalise(ligne,genreemployeur);
                ligne = mettreBalise(ligne,directionemployeur);
                ligne = mettreBalise(ligne,fonctionemployeur);
                ligne = mettreBalise(ligne,datededebut);
                ligne = mettreBalise(ligne,datedefin);
                ligne = mettreBalise(ligne,nombredejours);
                ligne = mettreBalise(ligne,salairedebase);
                ligne = mettreBalise(ligne,heuresupplementaire30);
                ligne = mettreBalise(ligne,heuresupplementaire40);
                ligne = mettreBalise(ligne,heuresupplementaire50);
                ligne = mettreBalise(ligne,heuresupplementaire100);
                ligne = mettreBalise(ligne,primedeRendement);
                ligne = mettreBalise(ligne,primedAnciennete);
                ligne = mettreBalise(ligne,majorationHeureNuit);
                ligne = mettreBalise(ligne,primediverse);
                ligne = mettreBalise(ligne,rappelsperiodeanterieure);
                ligne = mettreBalise(ligne,droitConge);
                ligne = mettreBalise(ligne,droitpreavis);
                ligne = mettreBalise(ligne,indemnitedelicenciement);
                ligne = mettreBalise(ligne,joursdAbsence);
                
                body_table = mettreBalise(body_table,ligne);
            }
            totaleAPaie.textContent = arrondiEnMilliersAvecEspace(totale_etat_de_paie);

        }
    };
    const dataToSend = {
        matricule : "none",
        date_debut : dateFiche,
    };
    xhr.send(JSON.stringify(dataToSend));
}

// Ajoutez un gestionnaire d'événements pour le changement de sélection
function validation() {
    // Récupérez les valeurs sélectionnées
    const dateFiche = date_fiche.value;
    //Appelez la fonction submitForm avec les valeurs en tant qu'arguments
    submitForm(dateFiche);
}

var mettreBalise = function(bMetre,bNouvelle) {
	bMetre.appendChild(bNouvelle);
	return bMetre;
}
var supprimerChild = function(bMere){
    while (bMere.firstChild) {
        bMere.removeChild(bMere.firstChild);
    }
    return bMere;
}