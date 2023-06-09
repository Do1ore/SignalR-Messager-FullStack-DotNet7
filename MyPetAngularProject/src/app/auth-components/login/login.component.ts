import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";
import { User } from "../../models/user";
import { environment } from "../../../environments/environment";
import { NavbarComponent } from "../../navbar/navbar.component";
import { ToastrService } from "ngx-toastr";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  user = new User();
  errorMessage: string = '';
  private authToken: string = environment.authTokenName;

  constructor(private authService: AuthService, private router: Router, private navBar: NavbarComponent,
    private toasterService: ToastrService) {
  }

  onSubmit(user: User) {
    this.authService.login(user).subscribe(async (token: string) => {
      this.errorMessage = '';
      localStorage.setItem(this.authToken, token)
      this.navBar.isAuthorized = true;
      await this.router.navigate(['']);
      this.toasterService.success('Success login', 'Success');
      this.authService.loginSubject.next();
    },
      error => {
        console.log(`error status : ${error.status} ${error.message}`);

        switch (error.status) {
          case 400:
            this.errorMessage = "Invalid input.";
            break;
          case 403:     //forbidden
            this.errorMessage = 'Forbidden.'
            break;
          case 500:
            this.errorMessage = 'Email not found.'
            break;
          default:
            this.errorMessage = "Unknown error"
            break;
        }
        this.toasterService.error(this.errorMessage + '😒', 'Error');
      });
  }
}
