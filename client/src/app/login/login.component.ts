import { Component, OnInit } from '@angular/core';
import { LOGIN_QUERY } from './queries';
import { Apollo } from 'apollo-angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public email="";
  public password="";
  constructor(private apollo: Apollo) { }

 

  ngOnInit(): void {
  }

  onSubmit(){
    if(this.validar()){
    this.apollo.watchQuery({
      query: LOGIN_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        email: this.email,
        password: this.password
      }
    }).valueChanges.subscribe(result => {

      var res : any;

      res = result;
      
      window.location.href= 'http://localhost:4200/main/' + res.data.login;
    });
    }

    else{
      alert("Favor rellenar todos los campos e intentar nuevamente");
    }

}

validar(){
  if(this.email !="" && this.password !=""){
    return true;
  }
  else{
    return false;
  }
}

}
