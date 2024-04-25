var tri = document.getElementById('triSelect');
var sort = document.getElementById('sortSelect');
var genre = document.getElementById('genreSelect');
var tbodyEmp = document.getElementById('bodyEmpTable');
var lignes = tbodyEmp.getElementsByTagName("tr");
var search = document.getElementById("searchbar");

var mettreBalise = function(bMetre,bNouvelle) {
	bMetre.appendChild(bNouvelle);
	return bMetre;
}
search.addEventListener("input", validation);

function addViewButton(row, matricule) {
    var colone8 = document.createElement('td');
    var viewButton = document.createElement('a');
    viewButton.href = "/Employer/Profil?Matricule=" + matricule;
    viewButton.className = "btnEntretien";
    var viewImage = document.createElement('img');
    viewImage.src = "/image/view.png";
    viewImage.alt = "";
    viewImage.style.width = "18px"; // Ajoutez cette ligne pour définir la largeur
    viewButton.appendChild(viewImage);
    colone8.appendChild(viewButton);
    row.appendChild(colone8);
}


function submitForm(triValue, sortValue, genreValue,searchValue) { 
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/employerAjaxSearch", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function () {
    if (xhr.status === 200) {
        var response = JSON.parse(xhr.responseText);

        for (var i = lignes.length - 1; i >= 0; i--) {
            tbodyEmp.removeChild(lignes[i]);
        }
                
        for (let index = 0; index < response.length ; index++) {
            var nouveauLigne = document.createElement('tr');
            var colone1 = document.createElement('td');
            var colone2 = document.createElement('td');
            var colone3 = document.createElement('td');
            var colone4 = document.createElement('td');
            var colone5 = document.createElement('td');
            var colone6 = document.createElement('td');
            var colone7 = document.createElement('td');


            colone1.textContent = response[index].matricule;
            colone2.textContent = response[index].firstName;
            colone3.textContent = response[index].lastName;
            colone4.textContent = response[index].genre;
            colone5.textContent = response[index].date_naissance;            
            colone6.textContent = response[index].direction;
            colone7.textContent = response[index].fonction;
            
            
            var lesColones = [colone1,colone2,colone3,colone4,colone5,colone6,colone7];
	        for (var i = 0; i < lesColones.length; i++) {
                nouveauLigne = mettreBalise(nouveauLigne,lesColones[i]);
        	}
            addViewButton(nouveauLigne, response[index].matricule);
	        tbodyEmp = mettreBalise(tbodyEmp,nouveauLigne);
        }
    }
    };
    const dataToSend = {
        tri : triValue,
        sort : sortValue,
        genre : genreValue,
        searchval : searchValue
    }
    xhr.send(JSON.stringify(dataToSend));
}

function validation() {
    const triValue = tri.value;
    const sortValue = sort.value;
    const genreValue = genre.value;
    const searchValue = search.value;
    submitForm(triValue, sortValue, genreValue,searchValue);
}
