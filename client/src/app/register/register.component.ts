import { Component, OnInit } from '@angular/core';
import { CREATE_USER } from './mutations';
import { Apollo } from 'apollo-angular';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  public name="";
  public lastName ="";
  public phone ="";
  public email="";
  public password="";

  constructor(private apollo: Apollo) { }


  ngOnInit(): void {
  }

  onSubmit(){
    
    if(this.validar()){
      this.apollo.mutate({
        mutation: CREATE_USER,
        variables: {
          input: {
          "name":this.name,
          "lastName" : this.lastName,
          "phone" : this.phone,
          "email":this.email,
          "password":this.password,
        }
      }
      }).subscribe((response) => {
        alert("Guardado con éxito");
        window.location.href = "http://localhost:4200/login";
  
      },error=> alert("Favor intentar nuevamente"));
    }
    else{
      alert("Favor rellenar todos los campos e intentar nuevamente");
    }
  }
    validar() {
      if(this.name !="" && this.lastName!="" && this.phone  !="" && this.email!="" && this.password!=""){
        return true;
      }
      else{
        return false;
      }
    }

}
