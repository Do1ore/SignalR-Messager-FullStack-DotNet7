import {Component, OnDestroy, OnInit} from '@angular/core';
import {ChatMainModel} from 'src/app/models/chatMainModel';
import {SignalRMessageService} from "../../services/signal-r-message.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, OnDestroy {
  constructor(
    public signalRMessageService: SignalRMessageService) {
  }


  private subscription: Subscription | undefined;
  public chatMainModel: ChatMainModel[] = [];

  async waitForHubConnection(): Promise<void> {
    while (this.signalRMessageService.getHubConnection().state != 'Connected') {
      //wait 100 milliseconds and check state again and again
      await new Promise(resolve => setTimeout(resolve, 100));
    }
  }

  async waitForMessages(): Promise<void> {
    while (this.signalRMessageService.chatModel == null) {
      //wait 100 milliseconds and check state again and again
      await new Promise(resolve => setTimeout(resolve, 100));
    }
  }

  async ngOnInit(): Promise<void> {
    await this.getChatInfo();
  }

  async getChatInfo(): Promise<void> {
    await this.waitForHubConnection();
    this.signalRMessageService.getHubConnection();
    this.signalRMessageService.getAllChatsForUserCaller();
    this.signalRMessageService.getAllChatsForUserListener();
    this.subscription = this.signalRMessageService.modelSubject.asObservable().subscribe((model: ChatMainModel[]) => {
      this.chatMainModel = model;


    })
    await this.waitForMessages();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
