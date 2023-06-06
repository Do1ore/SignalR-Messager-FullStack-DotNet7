import {Component, OnInit} from '@angular/core';
import {ChatDetailsComponent} from "../chat-details/chat-details.component";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-chat-domain',
  templateUrl: './chat-domain.component.html',
  styleUrls: ['./chat-domain.component.scss']
})
export class ChatDomainComponent implements OnInit {
  constructor(public authService: AuthService, private router: Router, public toaster: ToastrService) {
  }

  selectedChatId: string = '';

  public showChatDetails(chatId: string) {
    this.selectedChatId = chatId;
  }

  ngOnInit() {
    this.authService.logout$.subscribe(() => {
      this.router.navigate(['/login']).then();
      this.toaster.warning('To use chat you need to be authorized', 'Account required👁️');
      return;
    });
    if (!this.authService.isAuthorized()) {
      this.router.navigate(['/login']).then();
      this.toaster.warning('To use chat you need to be authorized', 'Account required💀');
      return;
    }
  }
}
