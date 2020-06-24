// login.component.ts
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "app-auth",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})

export class LoginComponent {
  user: User;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.user = {
            email: "",
            password:""
      };
  }

  login() {
   

    this.http.post(this.baseUrl + 'api/auth/login', this.user).subscribe((data) => {
    sessionStorage.setItem('token', data["token"])
    window.location.href = 'https://localhost:5001/vehicles';
  }, error => console.error(alert("Invalid email or password")));
  }
}


interface User {
    email: string;
    password: string;
}