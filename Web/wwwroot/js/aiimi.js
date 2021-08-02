function GetPerson() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:44304/api/person/getperson/name?fullname=" + document.getElementById("searchstring").value, true);
    xhr.send();

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            var response = JSON.parse(this.responseText);
            

            var node = document.getElementById("profile");
            let div = document.createElement('div');
            div.className = 'col-sm-4';
            div.innerHTML = '<div class="border border-3 border-white rounded-3"><p class="fw-bold">' + response.firstName + ' ' + response.lastName + '</p><p>' + response.jobTitle + '</p><p>' + response.phone + '</p><p>' + response.email + '</p></div>';
            node.appendChild(div);
        }
    };    
}

function addUser() {
    var xhttp = new XMLHttpRequest();

    xhttp.open("POST", "https://localhost:44304/api/person", true);
    xhttp.setRequestHeader("Content-type", "application/json");    
    var obj = { FirstName: document.getElementById("firstname").value, LastName: document.getElementById("lastname").value, JobTitle: document.getElementById("jobtitle").value, Phone: document.getElementById("phone").value, Email: document.getElementById("email").value };
    xhttp.send(JSON.stringify(obj));
    

    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            var response = JSON.parse(this.responseText);

            document.getElementById("fieldcontainer").style.display = 'none';

            var btndiv = document.getElementById("usersuccess");
            let btn = document.createElement('button');
            btn.className = 'btn-aiimi btn-usradded';
            btn.innerHTML = 'New user added! X';
            btndiv.appendChild(btn);
            //document.getElementById("#usersuccess").style.display = 'block';
            
            //jQuery("#usersuccess").show();
            
        }
    };   
}